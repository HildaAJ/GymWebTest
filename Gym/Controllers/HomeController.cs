using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.Models.ViewModels;
using Gym.Models;
using System.Threading.Tasks;
using System.Web.Security;
using Gym.Filters;
using Gym.Models.Operation;
using Newtonsoft.Json;
using Gym.Filter;

namespace Gym.Controllers
{
    
    public class HomeController : Controller
    {
        //[CommonAuthorize]
        public ActionResult Index()
        {
            try
            {
                RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserGuestAuth();
                if (pass == 0)
                {
                    ViewBag.UserName = roleAuth.UserName();
                }
                else if(pass == 1)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else if (pass == 2)
                {
                    ViewBag.RoleName = "Admin";
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員或以訪客身分瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                StoreOperation storeOp = new StoreOperation();
                var AllStore = storeOp.Get();//取得所有館別
                ClassroomOperation clsroomOp = new ClassroomOperation();
                var AllStoreClassRoom = clsroomOp.Get(AllStore);//取得所有館別的教室
                CourseOperation crsItemOp = new CourseOperation();
                CourseTypeOperation crsOp = new CourseTypeOperation();
                List<IndexViewModel> Lstmodel = new List<IndexViewModel>();
                
                //取得每個館別的資料
                foreach (var store in AllStore)
                {
                    IndexViewModel model = new IndexViewModel();
                    model.CourseInfo = new List<string>();

                    model.Store = store.Name;
                    model.AccessLimit = store.AccessLimit.ToString();
                    model.AccessNow = store.MemberInCnt.ToString();
                    
                    //取得該館的所有教室
                    var StoreClassRoom = clsroomOp.Get(store);

                    //若教室為一對一教練課用 跳過
                    foreach (var Room in StoreClassRoom)
                    {
                        if (Room.Name.Equals("一對一場地"))
                        {
                            continue;
                        }

                        var RoomName = Room.Name;
                        var LstCourse = crsItemOp.Get(Room);//取得教室的所有課程
                       
                        //取得教室目前課程 
                        var NowCourse = from c in LstCourse
                                         where c.CourseType_No != "Ch05" && c.ClassDate.Equals(DateTime.Now.Date)
                                         && c.StartTime <= DateTime.Now && DateTime.Now <= c.EndTime
                                         select c.CourseType_No;
                        
                        
                        //教室目前有課程
                        if (NowCourse.Count() > 0)
                        {
                            //取得教室名稱與目前課程名稱
                            var tmpNowCourse = NowCourse.ToList();
                            var courseName = crsOp.Get(tmpNowCourse[0]).Name;
                            model.CourseInfo.Add(RoomName + "：" + courseName);                                                      
                        }

                        //教室目前沒有課程
                        else
                        {
                            //取得教室名稱 紀錄目前無課程
                            model.CourseInfo.Add(RoomName + "：目前無課程");
                        }

                    }
                    Lstmodel.Add(model);
                }
                
                return View(Lstmodel);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return View();
            }                     
        }
        
        [AllowAnonymous]
        public ActionResult Create()
        {
            try
            {
                RegisterGroupViewModel reg = new RegisterGroupViewModel();
                //匯入館別複選資料
                StoreCheckListViewModel SCLV = new StoreCheckListViewModel();
                SCLV.listStoreItems();
                reg.StoreCheckList = SCLV;
                return View(reg);
            }
            catch (Exception ex)
            {
                ViewBag.RegisterMsg = ex.ToString();
                return View();
            }
            
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterGroupViewModel reg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string msg = "";

                    //新增會員至資料表
                    MemberOperation memberDataOperation = new MemberOperation();
                    var result = memberDataOperation.CheckAddMember(reg);

                    switch (result)
                    {
                        case 0:
                            msg = "註冊成功";
                            ViewBag.RegisterMsg = msg;
                            return RedirectToAction("Login", "Home");
                        case -1:
                            msg = "會員資料已存在 註冊失敗";
                            ViewBag.RegisterMsg = msg;
                            return View(reg);
                        case -2:
                            msg = "至少選擇一個館別";
                            ViewBag.RegisterMsg = msg;
                            return View(reg);
                        case -99:
                            msg = "會員資料新增失敗";
                            ViewBag.RegisterMsg = msg;
                            return View(reg);
                    }
                }
                return View(reg);
            }
            catch (Exception ex)
            {
                ViewBag.RegisterMsg = ex.ToString();
                return View(reg);
            }
            
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        { 
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                MemberOperation memberDataOperation = new MemberOperation();
                RoleOperation roleDataOperation = new RoleOperation();

                if (memberDataOperation.CheckUserData(model))
                {
                    LoginUser user = new LoginUser();
                    //登入會員的角色編號
                    var tmpRole = from c in memberDataOperation.Get()
                                  where model.Email == c.Email
                                  select c.Role_No;
                    
                    foreach (var item in tmpRole)
                    {
                        if (item.Equals(1))
                        {
                            user.Identity = Identity.User;
                        }
                        else if (item.Equals(2))
                        {
                            user.Identity = Identity.Admin;
                        }
                    }
                    //登入會員的名稱
                    user.UserName = memberDataOperation.user.Name;
                    //登入會員的帳號
                    user.UserEmail = memberDataOperation.user.Email.ToString();
 
                    FormsAuthManager authManager = new FormsAuthManager();
                    authManager.SignIn(user);
  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "無效的帳號或密碼。");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return View();
            }
            
                  
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthManager authManager = new FormsAuthManager();
            authManager.SignOut();
            //清除所有的 session
            Session.RemoveAll();
            ViewBag.Name = "Guest";
            return RedirectToAction("Index");
        }

    }
}
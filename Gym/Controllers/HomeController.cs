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


namespace Gym.Controllers
{
    
    public class HomeController : Controller
    {
        [LoginAuthorize]
        public ActionResult Index()
        {
            try
            {     
                StoreOperation storeOp = new StoreOperation();
                var AllStore = storeOp.Get();//取得所有館別
                ClassroomOperation clsroomOp = new ClassroomOperation();
                var AllStoreClassRoom = clsroomOp.Get(AllStore);//取得所有館別的教室
                CourseItemOperation crsItemOp = new CourseItemOperation();
                CourseOperation crsOp = new CourseOperation();
                List<IndexViewModel> Lstmodel = new List<IndexViewModel>();
                
                //取得每個館別的資料
                foreach (var store in AllStore)
                {
                    IndexViewModel model = new IndexViewModel();
                    model.CourseInfo = new List<string>();

                    model.Store = store.Name;
                    model.AccessLimit = 100.ToString();
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
                                         where c.Course_No != "Ch05" && c.ClassDate.Equals(DateTime.Now.Date)
                                         && c.StartTime <= DateTime.Now && DateTime.Now <= c.EndTime
                                         select c.Course_No;
                        
                        
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
            RegisterGroupViewModel reg = new RegisterGroupViewModel();
            //匯入館別複選資料
            StoreCheckListViewModel SCLV = new StoreCheckListViewModel();
            SCLV.listStoreItems();
            reg.StoreCheckList = SCLV;
            return View(reg);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterGroupViewModel reg)
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
                    //取得登入會員的角色編號
                    var tmpRole = from c in memberDataOperation.Get()
                                  where model.Email == c.Email
                                  select c.Role_No;
                    int RoleNo = 0;
                    foreach (var item in tmpRole)
                    {
                        RoleNo = item;
                    }

                    //取得會員的角色名稱
                    var RoleCollection = roleDataOperation.Get().Where(a => a.RoleNo == RoleNo).Select(a => a.Name);
                    string Role = "";
                    foreach (string item in RoleCollection)
                    {
                        Role = item;
                    }
                    // 1. 建立 ticket
                    var ticket = new FormsAuthenticationTicket(
                     version: 1,
                     name: memberDataOperation.user.Email.ToString(), //之後使用User.Identity.Name的值就是name的值
                     issueDate: DateTime.UtcNow,//現在UTC時間
                     expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
                     isPersistent: false,// 是否要記住我 true or false
                     userData: Role+","+ memberDataOperation.user.Name, 
                     cookiePath: FormsAuthentication.FormsCookiePath);

                    // 2. 加密 ticket
                    var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密

                    // 3. 建立 HttpCookie
                    //使用 FormsAuthentication 技術的話，HttpCookie 的 CookieName 要為
                    //FormsAuthentication.FormsCookieName，否則 FormsAuthentication 的驗證機制會失效。
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        HttpOnly = true
                    };

                    // 4. 使用者瀏覽器加入完成驗證的 Cookie
                    Response.Cookies.Add(cookie);
                    
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
            FormsAuthentication.SignOut();
            //清除所有的 session
            Session.RemoveAll();

            ViewBag.Name = "Guest";
            return RedirectToAction("Index");
        }

    }
}
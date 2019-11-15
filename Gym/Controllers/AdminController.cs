using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.Models.ViewModels.Admin;
using Gym.Models.Operation;
using Gym.Models;

namespace Gym.Controllers
{
    public class AdminController : Controller
    {
        RoleAuthManager roleAuth = new RoleAuthManager();

        // GET: Admin
        public ActionResult Index()
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
            return View();
        }

        /// <summary>
        /// 管理教練首頁 顯示所有教練資料
        /// </summary>
        /// <returns></returns>
        public ActionResult Teacher()
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //取得所有教練資料
                TeacherOperation operation = new TeacherOperation();
                var teacher = operation.Get();

                //放入顯示網頁的viewModel
                List<TeacherViewModel> models = new List<TeacherViewModel>();
                foreach (var item in teacher)
                {
                    var status = "";
                    if (item.Status.Equals(true))
                    {
                        status = "現役教練";
                    }
                    else { status = "目前無教學服務"; }

                    TeacherViewModel vm = new TeacherViewModel()
                    {
                        Name = item.Name,
                        CreateTime = item.CreateTime.ToString("yyyy-MM-dd").Substring(0, 10),
                        EMail = item.Email,
                        BirDate = item.Birthday.ToString("yyyy-MM-dd").Substring(0, 10),
                        TeacherNo = item.TeacherNo,
                        Status = status
                    };
                    models.Add(vm);
                }

                return View(models);
            }
            catch (Exception ex)
            {

                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }

        }

        /// <summary>
        /// 顯示編輯教練的資料
        /// </summary>
        /// <param name="id">教練id</param>
        /// <returns></returns>
        public ActionResult TeacherEdit(string id)
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                TeacherOperation operation = new TeacherOperation();
                var teacher = operation.Get(id);

                var status = "";
                if (teacher.Status.Equals(true))
                {
                    status = "現役教練";
                }
                else { status = "目前無教學服務"; }

                TeacherViewModel vm = new TeacherViewModel()
                {
                    Name = teacher.Name,
                    CreateTime = teacher.CreateTime.ToString("yyyy-MM-dd").Substring(0, 10),
                    EMail = teacher.Email,
                    BirDate = teacher.Birthday.ToString("yyyy-MM-dd").Substring(0, 10),
                    TeacherNo = teacher.TeacherNo,
                    Status = status
                };

                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        /// <summary>
        /// 存檔編輯後的教練資料
        /// </summary>
        /// <param name="model">教練資料</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherEdit(TeacherViewModel model)
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                TeacherOperation operation = new TeacherOperation();
                operation.Update(model);
                return RedirectToAction(nameof(Teacher));
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");

            }
        }


        /// <summary>
        /// 新增教練
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherAdd()
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherAdd(TeacherViewModel vm)
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //vm.CreateTime = DateTime.Now.ToString();

                TeacherOperation op = new TeacherOperation();
                var result = op.Add(vm);
                TempData["result"] = result;
                return RedirectToAction(nameof(Teacher));

            }
            catch (Exception ex)
            {

                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        /// <summary>
        /// 取得所有館別資料
        /// </summary>
        /// <returns></returns>
        public ActionResult Store()
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                StoreOperation op = new StoreOperation();
                var allStore = op.Get();

                List<StoreViewModel> lstModel = new List<StoreViewModel>();
                foreach (var item in allStore)
                {
                    StoreViewModel model = new StoreViewModel();
                    model.StoreNo = item.StoreNo;
                    model.Name = item.Name;
                    model.Address = item.Address;
                    model.Tel = item.Tel;
                    model.ServiceInfo = item.ServiceInfo;
                    model.ParkingInfo = item.ParkingInfo;
                    model.MemberInCnt = item.MemberInCnt.ToString();
                    model.AccessLimit = item.AccessLimit.ToString();

                    lstModel.Add(model);
                }

                return View(lstModel);
            }

            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        /// <summary>
        /// 編輯選取的館別資料
        /// </summary>
        /// <param name="id">館別id</param>
        /// <returns></returns>
        public ActionResult StoreEdit(string id)
        {

            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }


                StoreOperation op = new StoreOperation();
                var store = op.GetInfo(id);

                StoreViewModel model = new StoreViewModel()
                {
                    StoreNo = store.StoreNo,
                    Name = store.Name,
                    Address = store.Address,
                    Tel = store.Tel,
                    ServiceInfo = store.ServiceInfo,
                    ParkingInfo = store.ParkingInfo,
                    MemberInCnt = store.MemberInCnt.ToString(),
                    AccessLimit = store.AccessLimit.ToString()

                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");

            }

        }

        /// <summary>
        /// 存檔編輯的館別資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreEdit(StoreViewModel model)
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                StoreOperation op = new StoreOperation();
                op.Update(model);

                return RedirectToAction(nameof(Store));
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        /// <summary>
        /// 新增館別
        /// </summary>
        /// <returns></returns>
        public ActionResult StoreAdd()
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StoreAdd(StoreViewModel model)
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                StoreOperation op = new StoreOperation();
                var result = op.Add(model);
                TempData["result"] = result;
                return RedirectToAction(nameof(Store));


            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        /// <summary>
        /// 顯示所有教室資訊 照館別排列
        /// </summary>
        /// <returns></returns>
        public ActionResult Classroom()
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                StoreOperation storeOperation = new StoreOperation();
                ClassroomOperation classroomOperation = new ClassroomOperation();
                //取得所有館別ID
                var allStore = storeOperation.Get().Select(c=>c.StoreNo);

                //取得所有教室
                var allClassroom = classroomOperation.Get();

                List<ClassroomViewModel> LstModel = new List<ClassroomViewModel>();
                
                //根據現有館別歸納出各場館下的教室
                foreach (var StoreNo in allStore)
                {
                    ClassroomViewModel model = new ClassroomViewModel();
                    model.ClassInfo = new List<Dictionary<string, string>>();

                    //取得同館別的教室
                    var LstClsRoom = allClassroom.Where(c => c.Store_No.Equals(StoreNo)).Select(c => c);

                    model.StoreNo = StoreNo;
                    model.StoreName = storeOperation.GetName(StoreNo);
                    //取得同館別所有教室的Id及名稱
                    foreach (var item in LstClsRoom)
                    {
                        var DicClsInfo = new Dictionary<string, string>();
                        DicClsInfo.Add(item.ClassroomNo, item.Name);

                        model.ClassInfo.Add(DicClsInfo);
                    }

                    LstModel.Add(model);
                }

                    return View(LstModel);

            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }

        /// <summary>
        /// 顯示編輯的教室資訊
        /// </summary>
        /// <param name="storeNo">館別id</param>
        /// <param name="key">教室id</param>
        /// <returns></returns>
        public ActionResult ClsRoomEdit(string storeNo,string key)
        {
            try
            {
                //驗證授權：管理員
                var pass = roleAuth.AdminAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "Admin";
                }
                else
                {
                    TempData["Msg"] = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                ClassroomOperation op = new ClassroomOperation();
                var classroom=op.GetInfo(storeNo, key);

                return RedirectToAction(nameof(Classroom));


            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            }
        }
    }
}
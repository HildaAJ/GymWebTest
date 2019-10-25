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
                        Status=status
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
                var result=op.Add(vm);
                TempData["result"] = result;
                return RedirectToAction(nameof(Teacher));

            }
            catch (Exception ex)
            {

                TempData["Msg"] = ex.ToString();
                return RedirectToAction("Logout", "Home");
            } 
        }

    }
}
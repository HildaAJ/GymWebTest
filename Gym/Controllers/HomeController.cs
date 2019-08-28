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
            return View();
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
                MemberDataOperation memberDataOperation = new MemberDataOperation();
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
                MemberDataOperation memberDataOperation = new MemberDataOperation();
                RoleDataOperation roleDataOperation = new RoleDataOperation();

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

                    var ticket = new FormsAuthenticationTicket(
                     version: 1,
                     name: memberDataOperation.user.Email.ToString(), 
                     issueDate: DateTime.UtcNow,//現在UTC時間
                     expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
                     isPersistent: false,// 是否要記住我 true or false
                     userData: Role+","+ memberDataOperation.user.Name, 
                     cookiePath: FormsAuthentication.FormsCookiePath);

                    var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密

                    //使用 FormsAuthentication 技術的話，HttpCookie 的 CookieName 要為
                    //FormsAuthentication.FormsCookieName，否則 FormsAuthentication 的驗證機制會失效。
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        HttpOnly = true
                    };

                    Response.Cookies.Add(cookie);
                    //ViewBag.UserName = memberDataOperation.user.Name;
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //清除所有的 session
            Session.RemoveAll();

            ViewBag.Name = "Guest";
            return RedirectToAction("Index");
        }


        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Login(FormCollection post, string returnUrl)
        //{
        //    string email = post["email"];
        //    string password = post["password"];

        //    MemberDataOperation memberDataOperation = new MemberDataOperation();

        //    if (ModelState.IsValid)
        //    {
        //        //驗證密碼
        //        if (memberDataOperation.CheckUserData(email, password))
        //        {
        //            Session["account"] = email;
        //            Response.Redirect("~/Home/_UserAsidePartial");
        //            return new EmptyResult();
        //        }
        //        else
        //        {
        //            ViewBag.Msg = "登入失敗...";
        //            return View();
        //        }
        //    }

        //    return RedirectToAction("Login", "Home");

        //}

    }
}
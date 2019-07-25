using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.Models.ViewModels;
using Gym.Models;

namespace Gym.Controllers
{
    
    public class HomeController : Controller
    {
        //public GymDBModel db = new GymDBModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
                        return RedirectToAction("Index", "Home");
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
    }
}
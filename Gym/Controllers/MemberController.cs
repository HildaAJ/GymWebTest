using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gym.Filters;
using Gym.Models.Operation;
using Gym.Models.ViewModels;
using System.Web.Security;
using Gym.Models;
using Gym.Filter;
using System.Globalization;

namespace Gym.Controllers
{
    public class MemberController : Controller
    {
        /// <summary>
        /// 各館資訊
        /// </summary>
        /// <returns></returns>
        //[CommonAuthorize]
        public ActionResult StoreInfo()
        {
            try
            {
                //驗證授權：一般會員及訪客
                RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserGuestAuth();
                if (pass == 0)
                {
                    ViewBag.UserName = roleAuth.UserName();
                }
                else if (pass == 1)
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

                List<StoreInfoViewModel> stores = new List<StoreInfoViewModel>();

                foreach (var item in AllStore)
                {
                    StoreInfoViewModel storeVModel = new StoreInfoViewModel();
                    storeVModel.Name = item.Name;
                    storeVModel.Address = item.Address;
                    storeVModel.Tel = item.Tel;
                    storeVModel.Service = item.ServiceInfo;
                    storeVModel.Parking = item.ParkingInfo;
                    storeVModel.MemberInCount = item.MemberInCnt;

                    stores.Add(storeVModel);
                }

                return View(stores);
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return View();

            }

        }
        /// <summary>
        /// 顯示我的帳戶會員資料
        /// </summary>
        /// <returns></returns>
        public ActionResult Account()
        {
            try
            {
                //驗證授權：一般會員
                RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }

                //取得我的帳戶會員資料
                var Account = GetAccount();

                if (Account != null)
                {
                    List<MemberInfoViewModel> LstAccount = new List<MemberInfoViewModel>();
                    LstAccount.Add(Account);
                    return View(LstAccount);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {

                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }
        }

        /// <summary>
        /// 我的帳戶:修改會員基本資料
        /// </summary>
        /// <returns></returns>
        //[UserAuthorize(Roles = "User")]
        public ActionResult AccountInfo()
        {
            try
            {
                //驗證授權：一般會員
                RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }
                //取得我的帳戶會員資料
                var Account = GetAccount();

                if (Account != null)
                {
                    return View(Account);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");

            }
        }

        /// <summary>
        /// 我的帳戶：修改會員資料
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AccountInfo(MemberInfoViewModel Info)
        {
            try
            {
                //驗證授權：一般會員
                RoleAuthManager roleAuth = new RoleAuthManager();
                var pass = roleAuth.UserAuth();
                if (pass == true)
                {
                    ViewBag.UserName = roleAuth.UserName();
                    ViewBag.RoleName = "User";
                }
                else
                {
                    ViewBag.Msg = "無權限瀏覽該網頁，請登入會員瀏覽，謝謝！";
                    return RedirectToAction("Login", "Home");
                }
                MemberInfoViewModel afterEdit = new MemberInfoViewModel()
                {
                    Email = Info.Email,
                    Birthday = Info.Birthday,
                    CreateTime = Info.CreateTime,
                    Name = Info.Name,
                    Passway = Info.Passway,
                    Sex = Info.Sex,
                    Status = Info.Status,
                    Tel = Info.Tel
                };

                MemberOperation mo = new MemberOperation();
                mo.Update(afterEdit);

                return RedirectToAction("Account", "Member");
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex.ToString();
                return RedirectToAction("Login", "Home");
            }

        }

        //取得我的帳戶會員資料
        private MemberInfoViewModel GetAccount()
        {
            if (User.Identity.IsAuthenticated == true)//若會員為登入狀態
            {
                string Account = User.Identity.Name;//取得會員Email

                //找出該會員資料
                MemberOperation mo = new MemberOperation();
                var LstMember = mo.Get(Account);
                var member = LstMember[0];

                MemberInfoViewModel memInVM = new MemberInfoViewModel();
                string date = member.Birthday.ToString("yyyy-MM-dd").Substring(0, 10);
                memInVM.Email = member.Email;
                memInVM.Birthday = date;
                memInVM.CreateTime = member.CreateTime;
                memInVM.Name = member.Name;
                memInVM.Passway = member.PassWay;
                memInVM.Sex = member.Sex;

                if (member.Status == true)
                {
                    memInVM.Status = "有效會員";
                }
                else { memInVM.Status = "無效會員"; }
                memInVM.Tel = member.Tel;

                return memInVM;
            }
            else
            {
                return null;
            }
        }

    }
}
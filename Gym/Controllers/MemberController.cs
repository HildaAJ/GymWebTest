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

namespace Gym.Controllers
{
    public class MemberController : Controller
    {
        /// <summary>
        /// 各館資訊
        /// </summary>
        /// <returns></returns>
        [CommonAuthorize]
        public ActionResult StoreInfo()
        {
            try
            {
                StoreOperation storeOp = new StoreOperation();
                var AllStore = storeOp.Get();//取得所有館別

                List<StoreInfoViewModel> stores = new List<StoreInfoViewModel>();              

                foreach (var item in AllStore)
                {
                    StoreInfoViewModel storeVModel = new StoreInfoViewModel();
                    storeVModel.Name= item.Name;
                    storeVModel.Address=item.Address;
                    storeVModel.Tel= item.Tel ;
                    storeVModel.Service= item.ServiceInfo ;
                    storeVModel.Parking= item.ParkingInfo ;
                    storeVModel.MemberInCount= item.MemberInCnt ;

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
        /// 我的帳戶:顯示會員基本資料
        /// </summary>
        /// <returns></returns>
        [UserAuthorize(Roles = "User")]
        public ActionResult AccountInfo()
        {
            try
            {
                if (User.Identity.IsAuthenticated == true)//若會員為登入狀態
                {
                    string Account = User.Identity.Name;//取得會員Email
                    //找出該會員資料
                    MemberOperation mo = new MemberOperation();
                    var LstMember = mo.Get(Account);
                    var member = LstMember[0];

                    MemberInfoViewModel memInVM = new MemberInfoViewModel();
                    memInVM.Email = member.Email;
                    memInVM.Birthday = member.Birthday.ToString();
                    memInVM.CreateTime = member.CreateTime.ToString();
                    memInVM.Name = member.Name;
                    memInVM.Passway = member.PassWay; 
                    memInVM.Sex = member.Sex;
                    if (member.Status == true)
                    {
                        memInVM.Status = "有效會員";
                    }
                    else { memInVM.Status = "無效會員"; }
                    memInVM.Tel = member.Tel;

                    return View(memInVM);
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Home");

            } 
        }

        [HttpPost]
        [UserAuthorize(Roles = "User")]
        public ActionResult AccountInfo(MemberInfoViewModel EditMember)
        {
            return View();
        }
    }


    //將 Identity 轉型為 FormsIdentity，取得整個 FormsAuthenticationTicket
    //FormsIdentity id = (FormsIdentity)User.Identity;
    //FormsAuthenticationTicket ticket = id.Ticket;

    //string cookiePath = ticket.CookiePath;
    //DateTime expiration = ticket.Expiration;
    //bool expired = ticket.Expired;
    //bool isPersistent = ticket.IsPersistent;
    //DateTime issueDate = ticket.IssueDate;
    //string name = ticket.Name;
    //string userData = ticket.UserData;
    //int verstion = ticket.Version;

}
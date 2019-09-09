using Gym.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym.Filter
{
    /// <summary>
    /// 會員與訪客皆可授權
    /// </summary>
    public class CommonAuthorizeAttribute : AuthorizeAttribute
    {
        //驗證
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //登入驗證
            if (filterContext.HttpContext.User == null)
            {
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //取得獲取用戶的FormsAuthenticationTicket的UserData
                AuthManager authManager = new AuthManager();
                var userInfo = authManager.GetUser();
                var identity = userInfo.Identity.ToString();
                var Name = userInfo.UserName;
                filterContext.Controller.ViewBag.RoleName = identity;
                filterContext.Controller.ViewBag.UserName = Name;
            }
            else
            {
                //訪客 沒獲得授權 不處理授權失敗 直接過
                filterContext.Controller.ViewBag.UserName = "Guest";
            }
        }
        

    }
}
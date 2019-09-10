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
        AuthManager authManager = new AuthManager();
        LoginUser userInfo = new LoginUser();
        string identity = "";
        string Name = "";

        //驗證
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);//不能加~授權失敗會導至登入畫面

            //支援 MVC5 新增的 AllowAnonymous
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),
                    inherit: true);

            //訪客 不處理授權失敗 直接過
            //有設定 AllowAnonymous 就跳過
            var user = filterContext.HttpContext.User;
            if (skipAuthorization || !user.Identity.IsAuthenticated )
            {               
                filterContext.Controller.ViewBag.UserName = "Guest";
                return;
            }

            //會員登入的狀態
            //登入驗證
            if ((user == null) || !user.IsInRole("User"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                HandleUnauthorizedRequest(filterContext);
                return;
            }

            if (user.Identity.IsAuthenticated)
            {
                userInfo = authManager.GetUser();//使用者資料
                Name = userInfo.UserName;//使用者名字
                identity = userInfo.Identity.ToString();//使用者角色
                filterContext.Controller.ViewBag.RoleName = identity;//使用者角色
                filterContext.Controller.ViewBag.UserName = Name;
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
                HandleUnauthorizedRequest(filterContext);
            }

            //登入驗證
            //if (filterContext.HttpContext.User == null)
            //{
            //    HandleUnauthorizedRequest(filterContext);
            //    return;
            //}

            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    //取得獲取用戶的FormsAuthenticationTicket的UserData 
            //    userInfo = authManager.GetUser();
            //    identity = userInfo.Identity.ToString();
            //    Name = userInfo.UserName;
            //    filterContext.Controller.ViewBag.RoleName = identity;
            //    filterContext.Controller.ViewBag.UserName = Name;
            //}
            //else
            //{
            //    //訪客 沒獲得授權 不處理授權失敗 直接過
            //    filterContext.Controller.ViewBag.UserName = "Guest";
            //}
        }
        

    }
}
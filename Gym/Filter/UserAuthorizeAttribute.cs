using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;
using Gym.Models;
using Gym.Models.Operation;
using System.Linq;
using System.Web;
using System;

namespace Gym.Filters
{
    /// <summary>
    /// 一般會員filter
    /// </summary>
    public class UserAuthorize : AuthorizeAttribute
    {
        FormsAuthManager authManager = new FormsAuthManager();
        LoginUser userInfo = new LoginUser();
        string identity = "";
        string Name = "";
        

        //驗證
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //支援 MVC5 新增的 AllowAnonymous
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),
                    inherit: true);

            //有設定 AllowAnonymous 就跳過
            if (skipAuthorization)
            {
                return;
            }

            //登入驗證
            var user = filterContext.HttpContext.User;
            
            if ((user == null) || !user.Identity.IsAuthenticated || !user.IsInRole("User"))
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
                filterContext.Controller.ViewBag.RoleName = identity;
                filterContext.Controller.ViewBag.UserName = Name;
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();
                HandleUnauthorizedRequest(filterContext);
            }
        }
       
        /// <summary>
        /// 授權角色
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            IPrincipal user = httpContext.User;
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
 
            if (!httpContext.User.Identity.IsAuthenticated) 
                return false;                 

            //取得獲取用戶的FormsAuthenticationTicket的UserData(登入中使用者的資訊)
            userInfo = authManager.GetUser();
            //取得角色
            identity = userInfo.Identity.ToString();
           
            if (user.IsInRole(identity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 授權失敗處理
        /// </summary>
        /// <param name="filterContext"></param>
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if(filterContext.Result is HttpUnauthorizedResult)
        //    {
        //        //ContentResult cr = new ContentResult();
        //        //cr.Content = "<p style=\"color:Red;font-weight:bold;\">您尚未登入無法觀看!! 請先登入後再嘗試。</p>";
        //        //filterContext.Result = cr;
        //    }
        //}


    }



}

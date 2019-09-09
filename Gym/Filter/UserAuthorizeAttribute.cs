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
        //角色授權
        public UserAuthorize(string role) : base()
        {
            Roles = role;
        }

        
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
                ////獲取該用戶的FormsIdentity
                //FormsIdentity id = filterContext.HttpContext.User.Identity as FormsIdentity;
                ////再獲取用戶的FormsAuthenticationTicket
                //FormsAuthenticationTicket ticket = id.Ticket;

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
                HandleUnauthorizedRequest(filterContext);
            }
        }
        /// <summary>
        /// 授權失敗處理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.Result != null)
            {
                return;
            }
            base.HandleUnauthorizedRequest(filterContext); 
        }

        /// <summary>
        /// 授權角色
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
 
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;

            //取得使用者的角色
            AuthManager authManager = new AuthManager();
            var userInfo = authManager.GetUser();
            var identity = userInfo.Identity.ToString();
            if (identity.Equals(Roles))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    


}

using Gym.Models.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Gym
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                // 先取得該使用者的 FormsIdentity
                //FormsIdentity id = (FormsIdentity)User.Identity;
                //// 再取出使用者的 FormsAuthenticationTicket
                //FormsAuthenticationTicket ticket = id.Ticket;

                AuthManager auth = new AuthManager();
                var userData = auth.GetUser();
                // 將儲存在 FormsAuthenticationTicket 中的角色定義取出，並轉成字串陣列
                string[] roles = userData.Identity.ToString().Split(new char[] { ',' });
                //指派角色到目前這個 HttpContext 的 User 物件去
                //然後會把這個資料放到Context.User內
                Context.User = new GenericPrincipal(Context.User.Identity, roles);
            }

        }


    }
}

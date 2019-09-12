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
        /// <summary>
        /// 登入時將登入中角色加入 HttpContext 的 User 物件去 以便驗證授權用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                //取得登入者的資料
                FormsAuthManager auth = new FormsAuthManager();
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

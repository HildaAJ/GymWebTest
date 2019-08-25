using System.Web.Mvc;
using System.Web.Security;

namespace Gym.Models.Operation
{
    /// <summary>
    /// 自定義登入filter
    /// </summary>
    public class LoginAuthorize: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                FormsIdentity FormsIdentity = filterContext.HttpContext.User.Identity as FormsIdentity;
                filterContext.Controller.ViewBag.Name = FormsIdentity.Ticket.UserData;
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.Name = "Guest";
        }
    }
}
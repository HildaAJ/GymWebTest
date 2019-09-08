using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;
using Gym.Models;
using Gym.Models.Operation;
using System.Linq;

namespace Gym.Filters
{
    /// <summary>
    /// 自定義登入filter
    /// </summary>
   //public class LoginAuthorize : IAuthenticationFilter//AuthorizeAttribute
   // {
    //    RoleDataOperation roleDataOperation = new RoleDataOperation();
    //    MemberDataOperation memberDataOperation = new MemberDataOperation();

    //    public void OnAuthentication(AuthenticationContext filterContext)
    //    {
    //        if (filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.Principal.Identity is FormsIdentity)
    //        {
    //            var identity = (FormsIdentity)filterContext.Principal.Identity;
    //            FormsIdentity FormsIdentity = filterContext.HttpContext.User.Identity as FormsIdentity;
    //            //filterContext.Controller.ViewBag.Name = FormsIdentity.Ticket.UserData;
    //            var userdata = FormsIdentity.Ticket.UserData;
    //            if (userdata != null)
    //            {
    //                var user = memberDataOperation.Get().FirstOrDefault(u => u.MemberNo.ToString() == userdata);
    //                if (user != null)
    //                {
    //                    var roles = from c in roleDataOperation.Get()
    //                                where c.RoleNo == user.Role_No
    //                                select c.Name;
    //                    filterContext.Principal = new GenericPrincipal(identity, roles.ToArray());
    //                } 
    //            }
    //        }
    //        else
    //        {
    //            filterContext.Result = new HttpUnauthorizedResult();
    //        }
    //    }

    //    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
    //    {
    //        if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
    //        {
    //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
    //        {
    //            {"controller","Home"},
    //            {"action","Login"},
    //            {"returnUrl",filterContext.HttpContext.Request.RawUrl }
    //        });
    //        }
    //        //or do something , add challenge to response 
    //    }
    public class LoginAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)

        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                //獲取該用戶的FormsIdentity
                FormsIdentity id = filterContext.HttpContext.User.Identity as FormsIdentity;
                //再獲取用戶的FormsAuthenticationTicket
                FormsAuthenticationTicket ticket = id.Ticket;
                var userInfo = ticket.UserData;
                var User = userInfo.Split(',');
                filterContext.Controller.ViewBag.RoleName = User[0];
                filterContext.Controller.ViewBag.UserName = User[1];
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.UserName = "Guest";
        }
    }
    


}

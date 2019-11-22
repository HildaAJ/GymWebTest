using System.Web;
using System.Web.Mvc;
using Gym.Filters;

namespace Gym
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new LoginAuthorize());
        }
    }
}

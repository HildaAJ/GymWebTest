using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Gym.Models.Operation
{
    public class AuthManager
    {
        public void SignIn(LoginUser user)
        {
            // 1. 建立 ticket
            var ticket = new FormsAuthenticationTicket(
             version: 1,
             name: user.UserEmail, //之後使用User.Identity.Name的值就是name的值
             issueDate: DateTime.UtcNow,//現在UTC時間
             expiration: DateTime.UtcNow.AddMinutes(30),//Cookie有效時間=現在時間往後+30分鐘
             isPersistent: false,// 是否將 Cookie 設定成 Session Cookie，如果是則會在瀏覽器關閉後移除(記住我)
                                 //userData: Role+","+ memberDataOperation.user.Name,
             userData: JsonConvert.SerializeObject(user), //將要記錄的使用者資訊轉換為 JSON 字串
             cookiePath: FormsAuthentication.FormsCookiePath);

            // 2. 加密 ticket
            var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密

            // 3. 建立 HttpCookie
            //使用 FormsAuthentication 技術的話，HttpCookie 的 CookieName 要為
            //FormsAuthentication.FormsCookieName，否則 FormsAuthentication 的驗證機制會失效。
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true
            };

            // 4. 使用者瀏覽器加入完成驗證的 Cookie
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SignOut()
        {
            //移除瀏覽器的表單驗證
            FormsAuthentication.SignOut();
            
        }

        //取得使用者資訊
        public LoginUser GetUser()
        {
            //取得 ASP.NET 使用者
            var user = HttpContext.Current.User;

            //是否通過驗證
            if (user?.Identity?.IsAuthenticated == true)
            {
                //取得 FormsIdentity
                var identity = (FormsIdentity)user.Identity;

                //取得 FormsAuthenticationTicket
                var ticket = identity.Ticket;

                //將 Ticket 內的 UserData 解析回 User 物件
                return JsonConvert.DeserializeObject<LoginUser>(ticket.UserData);
            }
            return null;
        }

    }
}
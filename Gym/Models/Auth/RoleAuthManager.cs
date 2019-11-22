using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class RoleAuthManager
    {
        FormsAuthManager Auth = new FormsAuthManager();
        Identity identity = new Identity();

        //取得使用者名字
        public string UserName()
        {
            var userdata = Auth.GetUser();
            if (userdata != null)
            {
                var name = userdata.UserName;
                return name;
            }
            return "訪客";
        }

        //授權給一般會員
        public bool UserAuth()
        {
            var userdata=Auth.GetUser();
            if (userdata != null)
            {
                identity = userdata.Identity;
                if ((identity & Identity.User) == Identity.User)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //授權給管理者
        public bool AdminAuth()
        {
            var userdata = Auth.GetUser();
            if (userdata != null)
            {
                identity = userdata.Identity;
                if ((identity & Identity.Admin) == Identity.Admin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //授權給一般會員與訪客
        public int UserGuestAuth()
        {
            var userdata = Auth.GetUser();
            if (userdata != null)
            {
                identity = userdata.Identity;
                if ((identity & Identity.User) == Identity.User)
                {
                    return 1;
                }
                else
                {
                    //登入非一般會員身分
                    return 2;
                }
            }
            else
            {
                //訪客
                return 0;
            }
                
        }

    }
}
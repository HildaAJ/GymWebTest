using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gym.Models.Operation
{
    public class LoginUser
    {       
        //帳號
        public string UserEmail { get; set; }
        //名稱
        public string UserName { get; set; }
        //身分
        public Identity Identity { get; set; }
    }

    public enum Identity
    {
        [Description("管理者")]
        Admin = 0,

        [Description("一般使用者")]
        User = 1,
    }

}
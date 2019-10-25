using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels
{
    public class MemberInfoViewModel
    {
        [DisplayName("帳號")]
        public string Email { get; set; }

        [DisplayName("生日")]
        [Required(ErrorMessage = "出生日期不可空白")]
        public string Birthday { get; set; }

        [DisplayName("電話")]
        [Required(ErrorMessage = "電話不可空白")]
        [StringLength(maximumLength: 10, MinimumLength = 9, ErrorMessage = "請輸入正確的電話號碼")]
        [RegularExpression(@"^09[0-9]{8}", ErrorMessage = "手機號格式不正確")]
        public string Tel { get; set; }

        [DisplayName("性別")]
        [Required(ErrorMessage = "性別不可空白")]
        public string Sex { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string Name { get; set; }

        [DisplayName("進出方式")]
        public string Passway { get; set; }

        [DisplayName("加入日期")]
        public DateTime CreateTime { get; set; }

        [DisplayName("會員狀態")]
        public string Status { get; set; }
    }
}
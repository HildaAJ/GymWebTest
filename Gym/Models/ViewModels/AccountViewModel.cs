using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Gym.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("會員編號")]
        public string MemberNo { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string Name { get; set; }

        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage = "E-Mail格式有誤")]
        public string Email { get; set; }

        [DisplayName("出生年月日")]
        [Required(ErrorMessage = "出生日期不可空白")]
        public DateTime Birthday { get; set; }

        [DisplayName("電話")]
        [Required(ErrorMessage = "電話不可空白")]
        [StringLength(maximumLength: 10, MinimumLength = 9, ErrorMessage = "請輸入正確的電話號碼")]
        [RegularExpression(@"^09[0-9]{8}", ErrorMessage = "手機號格式不正確")]
        public string Tel { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("確認密碼")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密碼與確認密碼不符")]
        public string ConfirePassword { get; set; }

        [DisplayName("性別")]
        [Required(ErrorMessage = "請選擇性別")]
        public string Sex { get; set; }

        [DisplayName("進出方式")]
        [Required(ErrorMessage = "請選擇出入方式")]
        public string PassWay { get; set; } 

        public List<int> Store_No { get; set; }

        public int RoleNo { get { return 1; } }

        public DateTime CreateTime { get { return DateTime.Now; } }

        public DateTime LastLoginTime { get { return DateTime.Now; } }

        public bool IsLogin { get { return false; } }

        public bool Status { get { return true; } }
    }


    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "目前密碼")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認新密碼")]
        [Compare("NewPassword", ErrorMessage = "新密碼與確認密碼不相符。")]
        public string ConfirmPassword { get; set; }
    }


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }
}
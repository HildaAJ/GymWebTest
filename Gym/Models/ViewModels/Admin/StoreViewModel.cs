using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Gym.Models.ViewModels.Admin
{
    public class StoreViewModel
    {
        [DisplayName("館別編號")]
        public string StoreNo { get; set; }

        [DisplayName("館別名稱")]
        public string Name { get; set; }

        [DisplayName("地址")]
        public string Address { get; set; }

        [DisplayName("電話")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "請輸入正確格式的電話號碼")]
        [RegularExpression(@"0\d{1,2}-\d{6,8}", ErrorMessage = "請輸入正確格式的電話號碼")]
        public string Tel { get; set; }

        [DisplayName("營業時間")]
        public string ServiceInfo { get; set; }

        [DisplayName("停車資訊")]
        public string ParkingInfo { get; set; }

        [DisplayName("目前人數")]
        public string MemberInCnt { get; set; }

        [DisplayName("最多進場人數")]
        public string AccessLimit { get; set; }



    }
}
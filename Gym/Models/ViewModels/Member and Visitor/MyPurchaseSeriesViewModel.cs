using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;


namespace Gym.Models.ViewModels
{
    public class MyPurchaseSeriesViewModel
    {
        [DisplayName("編號")]
        public string Id { get; set; }

        [DisplayName("方案名稱")]
        public string Name { get; set; }

        [DisplayName("方案內容")]
        public string CourseInfo { get; set; }

        [DisplayName("價格")]
        public int Price { get; set; }

        [DisplayName("購買數量")]
        public int Count { get; set; }

        [DisplayName("購買日期")]
        public string Date { get; set; }

        [DisplayName("付款狀態")]
        public string PayStatus { get; set; }
    }
}
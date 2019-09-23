using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels
{
    //顯示點選的單筆消費方案
    public class SeriesDetailViewModel
    {
        [DisplayName("編號")]
        public string Id { get; set; }

        [DisplayName("名稱")]
        public string Name { get; set; }

        [DisplayName("方案內容")]
        public string CourseInfo { get; set; }

        [DisplayName("價格")]
        public int Price { get; set; }

        [DisplayName("數量")]
        [StringLength(maximumLength: 3, MinimumLength = 1, ErrorMessage = "可購買數量為1~99")]
        [RegularExpression(@"[0-9]{1,2}", ErrorMessage = "可購買數量為1~99")]
        public int Count { get; set; }
    }
}
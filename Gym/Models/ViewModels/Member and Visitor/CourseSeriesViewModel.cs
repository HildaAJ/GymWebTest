using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels
{
    //顯示所有消費方案
    public class CourseSeriesViewModel
    {
        [DisplayName("編號")]
        public string Id { get; set; }

        [DisplayName("名稱")]
        public string Name { get; set; }

        [DisplayName("方案介紹")]
        public string Description { get; set; }

        [DisplayName("方案內容")]
        public string CourseInfo { get; set; }

        [DisplayName("價格")]
        public int Price { get; set; }

        [DisplayName("販售期限")]
        public string DeadLine { get; set; }

    }

    
   
}
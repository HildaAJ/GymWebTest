using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Gym.Models.ViewModels
{
    public class FutureBookingViewModel
    {
        [DisplayName("課程代號")]
        public int CourseNo { get; set; }

        [DisplayName("課程")]
        public string CourseName { get; set; }

        [DisplayName("日期")]
        public string Date { get; set; }

        [DisplayName("上課時間")]
        public string Time { get; set; }

        [DisplayName("上課場館")]
        public string Store { get; set; }

        [DisplayName("教室")]
        public string Classroom { get; set; }

        [DisplayName("教練")]
        public string Teacher { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class IndexViewModel
    {
        public string Store { get; set; }//館別名稱 
        public List<string> CourseInfo { get; set; }//進行中的教室及課程資料
        public string AccessLimit { get; set; }//人數限制
        public string AccessNow { get; set; }//目前進場人數
        
    }
}
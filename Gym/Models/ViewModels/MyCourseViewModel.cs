using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels
{
    //我的課程
    public class MyCourseViewModel
    {
        [DisplayName("課程")]
        public string Name { get; set; }

        [DisplayName("堂數")]
        public int count { get; set; }
    }
}
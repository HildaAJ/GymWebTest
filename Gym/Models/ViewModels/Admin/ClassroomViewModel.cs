using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels.Admin
{
    public class ClassroomViewModel
    {
     
        public string StoreNo { get; set; }

        public string StoreName { get; set; }

        public List<Dictionary<string,string>> ClassInfo { get; set; }
    }
}
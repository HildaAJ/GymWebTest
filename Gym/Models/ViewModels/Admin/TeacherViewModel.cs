using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Gym.Models.ViewModels.Admin
{
    public class TeacherViewModel
    {
        [DisplayName("教練編號")]
        public string TeacherNo { get; set; }

        [DisplayName("教練名字")]
        public string Name { get; set; }

        [DisplayName("EMail")]
        public string EMail { get; set; }

        [DisplayName("生日")]
        public string BirDate { get; set; }

        [DisplayName("資料新增時間")]
        public string CreateTime { get; set; }

        [DisplayName("服務狀態")]
        public string Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class MemberInfoViewModel
    {
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Tel { get; set; }
        public string Sex { get; set; }
        public string Passway { get; set; }
        public string CreateTime { get; set; } 
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
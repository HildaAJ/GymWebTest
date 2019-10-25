using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class StoreInfoViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Service { get; set; }
        public string Parking { get; set; }
        public int? MemberInCount { get; set; }
    }
}
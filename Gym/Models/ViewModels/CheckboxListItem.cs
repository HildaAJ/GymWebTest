using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym.Models.ViewModels
{
    public class StoreCheckboxListItem
    {
        public string No { get; set; } 
        public string DisplayText { get; set; }
        public bool IsChecked { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels
{
    public class StoreCheckboxListItem
    {
        public string No { get; set; } 
        public string DisplayText { get; set; }

        [Display(Name = "館別")]
        [Required(ErrorMessage = "請至少選擇一個館別")]
        public bool IsChecked { get; set; }
    }
}
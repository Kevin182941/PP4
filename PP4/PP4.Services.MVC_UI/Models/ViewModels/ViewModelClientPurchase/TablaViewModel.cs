using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.MVC_UI.Models.ViewModels.ViewModelClientPurchase
{
    public class TablaViewModel
    {
        public int ID_Purchase { get; set; }

        [Required]
        [Display(Name = "Select a Batch")]
        public int ID_Batch { get; set; }

        [Required]
        [Display(Name = "Enter your Name")]
        public int ID_Person { get; set; }

        [Required]
        [Display(Name = "Select a Date")]
        [DataType(DataType.Date)]
        public DateTime Date_Purchase { get; set; }
    }
}
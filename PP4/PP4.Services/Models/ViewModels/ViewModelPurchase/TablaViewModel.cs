using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelPurchase
{
    public class TablaViewModel
    {
        public int ID_Purchase { get; set; }

        [Required]
        [Display(Name = "ID_Batch")]
        public int ID_Batch { get; set; }

        [Required]
        [Display(Name = "ID_Person")]
        public int ID_Person { get; set; }

        [Required]
        [Display(Name = "Date_Purchase")]
        [DataType(DataType.Date)]
        public DateTime Date_Purchase { get; set; }
    }
}
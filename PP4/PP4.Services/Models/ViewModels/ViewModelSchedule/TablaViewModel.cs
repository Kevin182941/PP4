using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelSchedule
{
    public class TablaViewModel
    {

        public int ID_Schedule { get; set; }

        [Required]
        [Display(Name = "Day")]
        [DataType(DataType.DateTime )]
        public DateTime Day { get; set; }

        [Required]
        [Display(Name = "State")]
        public bool State { get; set; }
      


    }

   
}
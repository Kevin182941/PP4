using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelMovie
{
    public class TablaViewModel
    {
        public int ID_Movie { get; set; }

        [Required]
        [Display(Name = "Description_Movie")]
        public string Description_Movie { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "State")]
        public bool State { get; set; }
    }
}
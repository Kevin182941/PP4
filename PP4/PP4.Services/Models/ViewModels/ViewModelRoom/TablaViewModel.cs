using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelRoom
{
    public class TablaViewModel
    {
        public int ID_Room { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "State")]
        public bool State { get; set; }
    }
}
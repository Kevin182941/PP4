using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels
{
    public class TablaViewModel
    {

       

        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Identification")]
        [StringLength(9)]
        public string Identification { get; set; }

        [Required]
        [Display(Name = "Mail")]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Ind_User")]
        public bool Ind_User { get; set; }

        [Required]
        [Display(Name = "Points")]
        public int Points { get; set; }

    }
}
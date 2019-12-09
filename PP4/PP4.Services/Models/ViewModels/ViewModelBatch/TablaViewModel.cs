using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelBatch
{
    public class TablaViewModel
    {
        public int ID_Batch { get; set; }

        [Required]
        [Display(Name = "ID_Room")]       
        public int ID_Room { get; set; }

        [Required]
        [Display(Name = "ID_Schedule")]    
        public int ID_Schedule { get; set; }

        [Required]
        [Display(Name = "ID_Movie")]   
        public int ID_Movie { get; set; }

    }
}
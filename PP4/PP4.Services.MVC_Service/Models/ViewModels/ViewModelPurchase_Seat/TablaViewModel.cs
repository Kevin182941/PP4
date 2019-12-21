using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.MVC_Service.Models.ViewModels.ViewModelPurchase_Seat
{
    public class TablaViewModel
    {
        public int ID_Purchase_Seat { get; set; }

        public int ID_Purchase { get; set; }

        public int ID_Seat { get; set; }

        [Required]
        [Display(Name = "ID_Room")]
        public int ID_Room { get; set; }

        [Required]
        [Display(Name = "Description_Seat")]
        public string Description_Seat { get; set; }

        [Required]
        [Display(Name = "Row")]
        public string Row { get; set; }

        [Required]
        [Display(Name = "Number")]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelPurcheaseSeat
{
    public class ListPurchaseSeatViewModel
    {
        public int ID_Purchase_Seat { get; set; }

        public int ID_Purchase { get; set; }

        public int ID_Seat { get; set; }

        public int ID_Room { get; set; }

        public string Description_Seat { get; set; }

        public string Row { get; set; }

        public int Number { get; set; }

        public decimal Price { get; set; }
    }
}
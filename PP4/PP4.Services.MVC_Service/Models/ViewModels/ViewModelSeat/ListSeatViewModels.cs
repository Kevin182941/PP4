using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.MVC_Service.Models.ViewModels.ViewModelSeat
{
    public class ListSeatViewModels
    {
        public int ID_Seat { get; set; }

        public int ID_Room { get; set; }

        public string Description_Seat { get; set; }

        public string Row { get; set; }

        public int Number { get; set; }

        public decimal Price { get; set; }
    }
}
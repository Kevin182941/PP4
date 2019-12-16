using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelSeat
{
    public class TablaVIewModel
    {
        public int ID_Seat { get; set; }

        public int ID_Room { get; set; }

        public string Description_Seat { get; set; }

        public string Row { get; set; }

        public int Number { get; set; }

        public decimal Price { get; set; }
    }
}
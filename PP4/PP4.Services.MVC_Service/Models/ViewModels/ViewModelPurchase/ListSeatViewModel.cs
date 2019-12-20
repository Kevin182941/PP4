using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.MVC_Service.Models.ViewModels.ViewModelPurchase
{
    public class ListSeatViewModel
    {
        public int ID_Purchase { get; set; }

        public int ID_Batch { get; set; }

        public int ID_Person { get; set; }

        public DateTime Date_Purchase { get; set; }
    }
}
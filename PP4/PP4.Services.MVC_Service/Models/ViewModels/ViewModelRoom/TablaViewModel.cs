using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.MVC_Service.Models.ViewModels.ViewModelRoom
{
    public class TablaViewModel
    {
        public int ID_Room { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public bool State { get; set; }
    }
}
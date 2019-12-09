using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels
{
    public class ListPersonViewModel
    {

        public int ID_Person { get; set; }

        public string Name { get; set; }

        public string Identification { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public bool Ind_User { get; set; }

        public int Points { get; set; }

    }
}
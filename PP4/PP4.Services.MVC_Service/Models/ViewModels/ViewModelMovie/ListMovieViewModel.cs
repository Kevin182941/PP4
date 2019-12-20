using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.MVC_Service.Models.ViewModels.ViewModelMovie
{
    public class ListMovieViewModel
    {
        public int ID_Movie { get; set; }

        public string Description_Movie { get; set; }

        public int Duration { get; set; }

        public bool State { get; set; }

    }
}
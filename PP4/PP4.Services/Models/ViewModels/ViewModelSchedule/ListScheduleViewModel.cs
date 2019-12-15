using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.Services.Models.ViewModels.ViewModelSchedule
{
    public class ListScheduleViewModel
    {
        public int ID_Schedule { get; set; }

        public DateTime Day { get; set; }

        public bool State { get; set; }

    }
}
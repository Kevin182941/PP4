using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelSeat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class SeatController : Controller
    {
        // GET: Seat
        public ActionResult Index()
        {
            List<ListSeatViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                lst = (from d in db.Persons
                       select new ListSeatViewModel
                       {
                           ID_Person = d.ID_Person,
                           Identification = d.Identification,
                           Name = d.Name,
                           Mail = d.Mail,
                           Password = d.Password,
                           Ind_User = d.Ind_User,
                           Points = d.Points


                       }).ToList();

            }
            return View(lst);

        }
    }
}
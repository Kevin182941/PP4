using PP4.Services.MVC.Services.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.MVC.Services.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Room[] listrooms = client.GetRooms();

            List<Room> list = new List<Room>();
            foreach (Room item in listrooms)
            {
                list.Add(new Room()
                {

                    ID_Room = item.ID_Room,
                    Capacity = item.Capacity,
                    Description = item.Description,
                    State = item.State,


                });
            }

            return View(list);
        }
    }
}
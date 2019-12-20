using PP4.Services.MVC_Service.Models.ViewModels.ViewModelRoom;
using PP4.Services.MVC_Service.ServiceReference1;
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
            Room[] listrooms = client.GetAllRooms();

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


        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(TablaViewModel model)
        {


            WebService1SoapClient client = new WebService1SoapClient();


            var room = new Room();
            room.ID_Room = model.ID_Room;
            room.Description = model.Description;
            room.Capacity = model.Capacity;           
            room.State = model.State;

            client.AddRoom(model.Description, model.Capacity, model.State);


            return Redirect("~/Room/");
        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            WebService1SoapClient client = new WebService1SoapClient();

            var room = client.GetRoom(id);

            model.Capacity = model.Capacity;
            model.Description = model.Description;
            model.State = model.State;
            model.ID_Room = room.ID_Room;


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TablaViewModel model)
        {
            WebService1SoapClient client = new WebService1SoapClient();

            try

            {
                if (ModelState.IsValid)
                {

                    var room = client.GetRoom(model.ID_Room);
                    room.Capacity = model.Capacity;
                    room.Description = model.Description;
                    room.State = model.State;


                    client.UpdateRoom(model.ID_Room, model.Description, model.Capacity, model.State);


                    return Redirect("~/Room/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {

            WebService1SoapClient client = new WebService1SoapClient();

            client.DeleteRoom(id);

            return Redirect("~/Room/");
        }
    }
}
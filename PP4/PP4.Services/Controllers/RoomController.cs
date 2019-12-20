using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            List<ListRoomViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                lst = (from d in db.Rooms
                       select new ListRoomViewModel
                       {
                           ID_Room = d.ID_Room,
                           Capacity = d.Capacity,
                           Description = d.Description,
                           State = d.State,                      


                       }).ToList();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.RoomController.ActionResult_Index" + ex.Message);

                }


            }
            return View(lst);

        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBContextCF db = new DBContextCF())
                    {

                        var room = new Room();
                        room.ID_Room = model.ID_Room;
                        room.Capacity = model.Capacity;
                        room.Description = model.Description;
                        room.State = model.State;
                       

                        db.Rooms.Add(room);
                        db.SaveChanges();

                    }
                    return Redirect("~/Room/");

                }

                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.RoomController.ActionResult_New(TablaViewModel model)" + ex.Message);

            }

        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                var room = db.Rooms.Find(id);

                model.Capacity = model.Capacity;
                model.Description = model.Description;
                model.State = model.State;
                model.ID_Room = room.ID_Room;

                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.RoomController.ActionResult_Edit(int id)" + ex.Message);
                }


            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (DBContextCF db = new DBContextCF())
                    {
                        var room = db.Rooms.Find(model.ID_Room);
                        room.Capacity = model.Capacity;
                        room.Description = model.Description;                        
                        room.State = model.State;                    



                        db.Entry(room).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/Room/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.RoomController.ActionResult_Edit(TablaViewModel model)" + ex.Message);

            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                var room = db.Rooms.Find(id);
                db.Rooms.Remove(room);
                db.SaveChanges();
                }
                catch (Exception)
                {

                    Console.WriteLine("ServicesMVC_Direct.RoomController.ActionResult_Delete" + ex.Message);
                }




            }
            return Redirect("~/Room/");
        }
    }
}
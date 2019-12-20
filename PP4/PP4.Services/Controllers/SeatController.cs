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
                try
                {
                lst = (from d in db.Seats
                       select new ListSeatViewModel
                       {
                           ID_Seat = d.ID_Seat,
                           ID_Room = d.ID_Room,
                           Description_Seat = d.Description_Seat,
                           Row = d.Row,
                           Number = d.Number,
                           Price = d.Price


                       }).ToList();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.SeatController.ActionResult_Index" + ex.Message);
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

                        try
                        {
                      var seat = new Seat();
                        seat.ID_Seat = model.ID_Seat;
                        seat.ID_Room = model.ID_Room;
                        seat.Description_Seat = model.Description_Seat;
                        seat.Row = model.Row;
                        seat.Number = model.Number;
                        seat.Price = model.Price;

                        db.Seats.Add(seat);
                        db.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("ServicesMVC_Direct.SeatController.ActionResult_New" + ex.Message);
                        }


                    }
                    return Redirect("~/Seat/");

                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {

                try
                {
                var seat = db.Seats.Find(id);

                
                model.Description_Seat = model.Description_Seat;
                model.ID_Room = model.ID_Room;                
                model.Row = model.Row;
                model.Number = model.Number;
                model.Price = model.Price;
                model.ID_Seat = seat.ID_Seat;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.SeatController.ActionResult_Edit(int id)" + ex.Message);
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
                        var seat = db.Seats.Find(model.ID_Seat);
                        seat.ID_Room = model.ID_Room;
                        seat.Description_Seat = model.Description_Seat;
                        seat.Row = model.Row;
                        seat.Number = model.Number;
                        seat.Price = model.Price;              
                        

                        db.Entry(seat).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/Seat/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.SeatController.ActionResult_Edit(TablaViewModel model)" + ex.Message);

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
                var seat = db.Seats.Find(id);
                db.Seats.Remove(seat);
                db.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.SeatController.ActionResult_Delete" + ex.Message);
                }



            }
            return Redirect("~/Seat/");
        }
    }
}
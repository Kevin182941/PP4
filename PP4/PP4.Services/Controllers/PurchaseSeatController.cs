using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelPurcheaseSeat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class PurchaseSeatController : Controller
    {
        // GET: PurchaseSeat
        public ActionResult Index()
        {
            List<ListPurchaseSeatViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                lst = (from d in db.Purchase_Seats
                       select new ListPurchaseSeatViewModel
                       {
                           ID_Purchase_Seat = d.ID_Purchase_Seat,
                           ID_Purchase = d.ID_Purchase,
                           ID_Seat = d.ID_Seat,                         


                       }).ToList();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.PurchaseSeatController.ActionResult_Index" + ex.Message);
                    ;
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

                        var purchase_Seat = new Purchase_Seat();
                        purchase_Seat.ID_Purchase_Seat = model.ID_Purchase_Seat;
                        purchase_Seat.ID_Purchase = model.ID_Purchase;
                        purchase_Seat.ID_Seat = model.ID_Seat;
                      
                        db.Purchase_Seats.Add(purchase_Seat);
                        db.SaveChanges();

                    }
                    return Redirect("~/PurchaseSeat/");

                }

                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.PurchaseSeatController.ActionResult_New(TablaViewModel model)" + ex.Message);
            }

        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                var purchase_seat = db.Purchase_Seats.Find(id);

                model.ID_Purchase = model.ID_Purchase;
                model.ID_Seat = model.ID_Seat;             
                model.ID_Purchase_Seat = purchase_seat.ID_Purchase_Seat;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.PurchaseSeatController.ActionResult_Edit(id)" + ex.Message);

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
                        var purchase_seat = db.Purchase_Seats.Find(model.ID_Purchase_Seat);
                        purchase_seat.ID_Purchase = model.ID_Purchase;
                        purchase_seat.ID_Seat = model.ID_Seat;
                      

                        db.Entry(purchase_seat).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/PurchaseSeat/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.PurchaseSeatController.ActionResult_Edit(TablaViewModel model)" + ex.Message);


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
                var purchase_seat = db.Purchase_Seats.Find(id);
                db.Purchase_Seats.Remove(purchase_seat);
                db.SaveChanges();
                }
                catch (Exception)
                {

                    Console.WriteLine("ServicesMVC_Direct.PurchaseSeatController.ActionResult_Delete" + ex.Message);
                }



            }
            return Redirect("~/Person/");
        }


    }
}
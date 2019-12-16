﻿using PP4.DAL;
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
                lst = (from d in db.Purchase_Seats
                       select new ListPurchaseSeatViewModel
                       {
                           ID_Purchase_Seat = d.ID_Purchase_Seat,
                           ID_Purchase = d.ID_Purchase,
                           ID_Seat = d.ID_Seat,                         


                       }).ToList();

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
                throw new Exception(ex.Message);

            }

        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {

                var purchase_seat = db.Purchase_Seats.Find(id);

                model.ID_Purchase = model.ID_Purchase;
                model.ID_Seat = model.ID_Seat;
             
                model.ID_Purchase_Seat = purchase_seat.ID_Purchase_Seat;

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
                throw new Exception(ex.Message);

            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {

                var purchase_seat = db.Purchase_Seats.Find(id);
                db.Purchase_Seats.Remove(purchase_seat);
                db.SaveChanges();


            }
            return Redirect("~/Person/");
        }


    }
}
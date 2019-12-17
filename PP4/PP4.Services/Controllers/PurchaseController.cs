using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelPurchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchease
        public ActionResult Index()
        {
            List<ListPurchaseViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                lst = (from d in db.Purchases
                       select new ListPurchaseViewModel
                       {
                           ID_Purchase = d.ID_Purchase,
                           ID_Batch = d.ID_Batch,
                           ID_Person = d.ID_Person,
                           Date_Purchase = d.Date_Purchase,
                          

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

                        var purchase = new Purchase();

                        purchase.ID_Purchase = model.ID_Purchase;
                        purchase.ID_Batch = model.ID_Batch;
                        purchase.ID_Person = model.ID_Person;                  
                        purchase.Date_Purchase = model.Date_Purchase;
                       

                        db.Purchases.Add(purchase);
                        db.SaveChanges();

                    }
                    return Redirect("~/Purchase/");

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

                var purchase = db.Purchases.Find(id);

                model.ID_Batch = model.ID_Batch;
                model.ID_Person = model.ID_Person;
                model.Date_Purchase = model.Date_Purchase;
                model.ID_Purchase = purchase.ID_Purchase;

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
                        var purchase = db.Purchases.Find(model.ID_Purchase);                        
                        purchase.ID_Batch = model.ID_Batch;
                        purchase.ID_Person = model.ID_Person;
                        purchase.Date_Purchase = model.Date_Purchase;
                    

                        db.Entry(purchase).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/Purchase/");
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

                var purchase = db.Purchases.Find(id);
                db.Purchases.Remove(purchase);
                db.SaveChanges();


            }
            return Redirect("~/Purchase/");
        }
    }
}

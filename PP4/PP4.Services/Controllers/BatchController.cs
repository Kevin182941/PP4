using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelBatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            List<ListBatchViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                lst = (from d in db.Batches
                       select new ListBatchViewModel
                       {
                           ID_Batch = d.ID_Batch,
                           ID_Room = d.ID_Room,
                           ID_Schedule = d.ID_Schedule,
                           ID_Movie = d.ID_Movie,

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

                        var batch = new Batch();
                        batch.ID_Movie = model.ID_Movie;
                        batch.ID_Room = model.ID_Room;
                        batch.ID_Schedule = model.ID_Schedule;
                        batch.ID_Movie = model.ID_Movie;
                       

                        db.Batches.Add(batch);
                        db.SaveChanges();

                    }
                    return Redirect("~/Batch/");

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

                var batch = db.Batches.Find(id);

                model.ID_Room = model.ID_Room;
                model.ID_Schedule = model.ID_Schedule;
                model.ID_Movie = model.ID_Movie;
                model.ID_Batch = batch.ID_Batch;


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
                        var batch = db.Batches.Find(model.ID_Batch);                      
                        batch.ID_Room = model.ID_Room;
                        batch.ID_Schedule = model.ID_Schedule;
                        batch.ID_Movie = model.ID_Movie;
                       


                        db.Entry(batch).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/Batch/");
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

                var batch = db.Batches.Find(id);
                db.Batches.Remove(batch);
                db.SaveChanges();


            }
            return Redirect("~/Batch/");
        }

    }
}
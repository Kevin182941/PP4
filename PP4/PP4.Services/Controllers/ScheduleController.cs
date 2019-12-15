using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            List<ListScheduleViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                lst = (from d in db.Schedules
                       select new ListScheduleViewModel
                       {
                           ID_Schedule = d.ID_Schedule,
                           Day = d.Day,                           
                           State = d.State

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

                        var schedule = new Schedule();
                        schedule.ID_Schedule = model.ID_Schedule;
                        schedule.Day = model.Day;
                        schedule.State = model.State;


                        db.Schedules.Add(schedule);
                        db.SaveChanges();

                    }
                    return Redirect("~/Schedule/");

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

                var schedule = db.Schedules.Find(id);

                model.ID_Schedule = model.ID_Schedule;
                model.Day = model.Day;
                model.State = model.State;
               
                model.ID_Schedule = schedule.ID_Schedule;

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
                        var schedule = db.Schedules.Find(model.ID_Schedule);
                        schedule.ID_Schedule = model.ID_Schedule;
                        schedule.Day = model.Day;
                        schedule.State = model.State;

                        db.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/Schedule/");
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

                var schedule = db.Schedules.Find(id);
                db.Schedules.Remove(schedule);
                db.SaveChanges();


            }
            return Redirect("~/Schedule/");
        }
    }
}
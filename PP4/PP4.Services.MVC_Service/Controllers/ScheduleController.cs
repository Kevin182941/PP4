using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PP4.Services.MVC_Service.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Room[] listShedule = client.GetAllShedule();

            List<Shedule> list = new List<Shedule>();
            foreach (Shedule item in listshedule)
            {
                list.Add(new Shedule()
                {

                    ID_Schedule = item.ID_Schedule,
                    Day = item.Day,
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

            var schedule = new Schedule();
            schedule.ID_Schedule = model.ID_Schedule;
            schedule.Day = model.Day;
            schedule.State = model.State;

            client.AddSchedule(model.ID_Schedule, model.Day, model.State);


            return Redirect("~/Schedule/");
        }
        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            WebService1SoapClient client = new WebService1SoapClient();

            var schedule = client.GetSchedule(id);

            model.Day = model.Day;
            model.State = model.State;
            model.ID_Schedule = schedule.ID_Schedule;


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

                    var schedule = client.GetSchedule(model.ID_Schedule);
                    schedule.ID_Schedule = model.ID_Schedule;
                    schedule.Day = model.v;
                    schedule.State = model.State;


                    client.UpdateSchedule(model.ID_Schedule, model.Day, model.State);


                    return Redirect("~/Schedule/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        [HttpGet]
        public ActionResult Delete(int id)
        {

            WebService1SoapClient client = new WebService1SoapClient();

            client.DeleteSchedule(id);

            return Redirect("~/Schedule/");
        }
    }
    }
}
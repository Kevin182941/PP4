using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PP4.Services.MVC_Service.ServiceReference1;
using PP4.Services.MVC_Service.Models.ViewModels.ViewModelBatch;

namespace PP4.Services.MVC_Service.Controllers
{
    public class BatchController : ApiController
    {
        // GET: Batch
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Batch[] listBatch = client.GetAllMovies();

            List<Batch> list = new List<Batch>();
            foreach (Batch item in listbatch)
            {
                list.Add(new Batch()
                {
                    ID_Movie = item.ID_Movie,
                    Description_Movie = item.Description_Movie,
                    Duration = item.Duration,
                    State = item.State
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


            var movie = new Movie();
            movie.ID_Batch = model.ID_Batch;
            movie.ID_Room = model.ID_Room;
            movie.ID_Schedule = model.ID_Schedule;
            movie.ID_Movie = model.ID_Movie;

            client.AddBatch(model.ID_Batch, model.ID_Room, model.ID_Schedule, model.ID_Movie);


            return Redirect("~/Batch/");
        }
        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();

            WebService1SoapClient client = new WebService1SoapClient();


            var movie = client.GetMovie(id);

            model.ID_Batch = model.ID_Batch;
            model.ID_Room = model.ID_Room;
            model.ID_Schedule = model.ID_Schedule;
            model.ID_Movie = batch.ID_Movie;


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

                    var bacth = client.GetMovie(model.ID_Batch);
                    bacth.ID_Room = model.ID_Room;
                    bacth.ID_Schedule = model.ID_Schedule;
                    bacth.ID_Movie = model.ID_Movie;


                    client.UpdateBatch(model.ID_Batch, model.ID_Room, model.ID_Schedule, model.ID_Movie);


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

            WebService1SoapClient client = new WebService1SoapClient();

            client.DeleteBatch(id);

            return Redirect("~/Batch/");
        }

    }
}
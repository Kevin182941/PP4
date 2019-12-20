
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.Services.MVC_Service.ServiceReference1;
using PP4.Services.MVC_Service.Models.ViewModels.ViewModelMovie;

namespace PP4.Services.MVC_Service.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Movie[] listmovies = client.GetAllMovies();

            List<Movie> list = new List<Movie>();
            foreach (Movie item in listmovies)
            {
                list.Add(new Movie()
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
            movie.ID_Movie = model.ID_Movie;
            movie.Description_Movie = model.Description_Movie;
            movie.Duration = model.Duration;
            movie.State = model.State;

            client.AddMovie(model.ID_Movie, model.Description_Movie, model.Duration, model.State);


            return Redirect("~/Movie/");
        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();

            WebService1SoapClient client = new WebService1SoapClient();


            var movie = client.GetMovie(id);

            model.ID_Movie = model.ID_Movie;
            model.Description_Movie = model.Description_Movie;
            model.Duration = model.Duration;
            model.State = model.State;
            model.ID_Movie = movie.ID_Movie;


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

                    var movie = client.GetMovie(model.ID_Movie);
                    movie.Description_Movie = model.Description_Movie;
                    movie.Duration = model.Duration;
                    movie.State = model.State;


                    client.UpdateMovie(model.ID_Movie, model.Description_Movie, model.Duration, model.State);


                    return Redirect("~/Movie/");
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

            client.DeleteMovie(id);

            return Redirect("~/Movie/");
        }
    }
}
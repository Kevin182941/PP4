using PP4.DAL;
using PP4.Services.Models.ViewModels.ViewModelMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
      
        public ActionResult Index()
        {
            List<ListMovieViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                lst = (from d in db.Movies
                       select new ListMovieViewModel
                       {
                           ID_Movie = d.ID_Movie,
                           Description_Movie = d.Description_Movie,
                           Duration = d.Duration,
                           State = d.State                      


                       }).ToList();

                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.MovieController.ActionResult_Index" + ex.Message);
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

                        var movie = new Movie();
                        movie.ID_Movie = model.ID_Movie;
                        movie.Description_Movie = model.Description_Movie;
                        movie.Duration = model.Duration;
                        movie.State = model.State;
                        

                        db.Movies.Add(movie);
                        db.SaveChanges();

                    }
                    return Redirect("~/Movie/");

                }

                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.MovieController.ActionResult_New(TablaViewModel model)" + ex.Message);

            }

        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {
                try
                {

                var movie = db.Movies.Find(id);

                model.ID_Movie = model.ID_Movie;
                model.Description_Movie = model.Description_Movie;
                model.Duration = model.Duration;
                model.State = model.State;            
                model.ID_Movie = movie.ID_Movie;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.MovieController.ActionResult_Edit" + ex.Message);
                    
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
                        var movie = db.Movies.Find(model.ID_Movie);
                        movie.Description_Movie = model.Description_Movie;
                        movie.Duration = model.Duration;
                        movie.State = model.State;               
                

                        db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }

                    return Redirect("~/Movie/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.MovieController.ActionResult_New(TablaViewModel model)" + ex.Message);

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
                var movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();
                }
                catch (Exception)
                {

                    Console.WriteLine("ServicesMVC_Direct.MovieController.ActionResult_Delete" + ex.Message);
                    
                }



            }
            return Redirect("~/Movie/");
        }
    }
}

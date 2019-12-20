using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            try
            {
            ViewBag.Message = "Your application description page.";

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.HomeController.ActionResult_About" + ex.Message);

            }

            return View();
        }

      
        public ActionResult Contact()
        {

            try
            {
            ViewBag.Message = "Your contact page.";

            }
            catch (Exception ex)
            {

                Console.WriteLine("ServicesMVC_Direct.HomeController.ActionResult_Contact" + ex.Message);
            }

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PP4.Services.MVC_Service.Controllers
{
    public class MainController : ApiController
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

    }
}
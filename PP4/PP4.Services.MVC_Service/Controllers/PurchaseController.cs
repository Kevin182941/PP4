using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.Services.MVC_Service.ServiceReference1;
using PP4.Services.MVC_Service.Models.ViewModels.ViewModelPurchase;

namespace PP4.Services.MVC_Service.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Purchase[] listpurchases = client.GetAllPurchases();

            List<Purchase> list = new List<Purchase>();
            foreach (Purchase item in listpurchases)
            {
                list.Add(new Purchase()
                {

                    ID_Purchase = item.ID_Purchase,
                    ID_Batch = item.ID_Batch,
                    ID_Person = item.ID_Person,
                    Date_Purchase = item.Date_Purchase,


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


            var purchase = new Purchase();

            purchase.ID_Purchase = model.ID_Purchase;
            purchase.ID_Batch = model.ID_Batch;
            purchase.ID_Person = model.ID_Person;
            purchase.Date_Purchase = model.Date_Purchase;


            client.AddPurchase(model.ID_Batch, model.ID_Person, model.Date_Purchase);


            return Redirect("~/Purchase/");
        }

        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
            WebService1SoapClient client = new WebService1SoapClient();

            var purchase = client.GetPurchase(id);

            model.ID_Batch = model.ID_Batch;
            model.ID_Person = model.ID_Person;
            model.Date_Purchase = model.Date_Purchase;
            model.ID_Purchase = purchase.ID_Purchase;

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

                    var purchase = client.GetPurchase(model.ID_Purchase);
                    purchase.ID_Batch = model.ID_Batch;
                    purchase.ID_Person = model.ID_Person;
                    purchase.Date_Purchase = model.Date_Purchase;



                    client.UpdatePurchase(model.ID_Purchase,model.ID_Batch, model.ID_Person, model.Date_Purchase);


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

            WebService1SoapClient client = new WebService1SoapClient();

            client.DeletePurchase(id);

            return Redirect("~/Purchase/");
        }
    }
}
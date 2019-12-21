using PP4.Services.MVC_Service.Models.ViewModels.ViewModelSeat;
using PP4.Services.MVC_Service.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.Services.MVC_Service.Controllers
{
    public class SeatController : Controller
    {
        // GET: Seat
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Seat[] listseat = client.GetAllSeats();

            List<Seat> list = new List<Seat>();
            foreach (Seat item in listseat)
            {
                list.Add(new Seat()
                {
                    
                    ID_Seat = item.ID_Seat,
                    ID_Room = item.ID_Room,
                    Description_Seat = item.Description_Seat,
                    Row = item.Row,
                    Number = item.Number,
                    Price = item.Price

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


            var seat = new Seat();
            seat.ID_Seat = model.ID_Seat;
            seat.ID_Room = model.ID_Room;
            seat.Description_Seat = model.Description_Seat;
            seat.Row = model.Row;
            seat.Number = model.Number;
            seat.Price = model.Price;

            client.AddSeat(model.ID_Room, model.Description_Seat, model.Row, model.Number, model.Price);


            return Redirect("~/Seat/");
        }

        public ActionResult Edit(int id)
        {
            WebService1SoapClient client = new WebService1SoapClient();
            TablaViewModel model = new TablaViewModel();

            var seat = client.GetSeat(id);


            model.Description_Seat = model.Description_Seat;
            model.ID_Room = model.ID_Room;
            model.Row = model.Row;
            model.Number = model.Number;
            model.Price = model.Price;
            model.ID_Seat = seat.ID_Seat;


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



                    var seat = client.GetSeat(model.ID_Seat);
                    seat.ID_Room = model.ID_Room;
                    seat.Description_Seat = model.Description_Seat;
                    seat.Row = model.Row;
                    seat.Number = model.Number;
                    seat.Price = model.Price;


                    client.UpdateSeat(model.ID_Seat,model.ID_Room, model.Description_Seat, model.Row, model.Number, model.Price);

                    return Redirect("~/Seat/");
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

            client.DeleteSeat(id);

            return Redirect("~/Seat/");
        }
    }
}
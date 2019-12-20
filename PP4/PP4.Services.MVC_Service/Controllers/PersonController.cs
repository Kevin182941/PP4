using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PP4.Services.MVC_Service.Models.ViewModels.ViewModelPerson;
using PP4.Services.MVC_Service.ServiceReference1;




namespace PP4.Services.MVC.Services.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            Person[] listpeople = client.GetAllPeople();

            List<Person> list = new List<Person>();
            foreach (Person item in listpeople)
            {
                list.Add(new Person()
                {

                    ID_Person = item.ID_Person,
                    Identification = item.Identification,
                    Name = item.Name,
                    Mail = item.Mail,
                    Password = item.Password,
                    Ind_User = item.Ind_User,
                    Points = item.Points,

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


            var person = new Person();
            person.ID_Person = model.ID_Person;
            person.Identification = model.Identification;
            person.Name = model.Name;
            person.Mail = model.Mail;
            person.Password = model.Password;
            person.Ind_User = model.Ind_User;
            person.Points = model.Points;

            client.AddPerson(model.Identification, model.Name, model.Mail, model.Password,model.Points, model.Ind_User);


            return Redirect("~/Person/");
        }

        public ActionResult Edit(int id)
        {
            WebService1SoapClient client = new WebService1SoapClient();
            TablaViewModel model = new TablaViewModel();
          
                var person = client.GetPerson(id);

                model.Identification = model.Identification;
                model.Name = model.Name;
                model.Mail = model.Mail;
                model.Password = model.Password;
                model.Ind_User = model.Ind_User;
                model.Points = model.Points;
                model.ID_Person = person.ID_Person;

          
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

                   

                        var person = client.GetPerson(model.ID_Person);
                        person.Identification = model.Identification;
                        person.Name = model.Name;
                        person.Mail = model.Mail;
                        person.Password = model.Password;
                        person.Ind_User = model.Ind_User;
                        person.Points = model.Points;

                        client.UpdatePerson(model.ID_Person, model.Identification, model.Name, model.Mail, model.Password, model.Points ,model.Ind_User);

                   
                    return Redirect("~/Person/");
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

            client.DeletePerson(id);

            return Redirect("~/Person/");
        }
    }
}

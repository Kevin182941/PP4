using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.DAL;
using PP4.Services;
using PP4.Services.Models.ViewModels;

namespace PP4.Services.Controllers
{
    public class PersonController : Controller
    {
      
        // GET: Person
        public ActionResult Index()
        {
            List<ListPersonViewModel> lst;
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                lst = (from d in db.Persons
                       select new ListPersonViewModel
                       {
                           ID_Person = d.ID_Person,
                           Identification = d.Identification,
                           Name = d.Name,
                           Mail = d.Mail,
                           Password = d.Password,
                           Ind_User = d.Ind_User,
                           Points = d.Points


                       }).ToList();
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.PersonController.ActionResult_Index" + ex.Message);

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
                        
                        var person = new Person();
                        person.ID_Person = model.ID_Person;
                        person.Identification = model.Identification;
                        person.Name = model.Name;
                        person.Mail = model.Mail;
                        person.Password = model.Password;
                        person.Ind_User = model.Ind_User;
                        person.Points = model.Points;

                        db.Persons.Add(person);
                        db.SaveChanges();
                    
                    }
                    return Redirect("~/Person/");

                }

                return View(model);

            } catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.PersonController.ActionResult_New(TablaViewModel model)" + ex.Message);

            }

        }

        public ActionResult Edit(int id)    
        {
            TablaViewModel model = new TablaViewModel();
            using (DBContextCF db = new DBContextCF())
            {
                try
                {
                var person = db.Persons.Find(id);
            
                model.Identification = model.Identification;
                model.Name = model.Name;
                model.Mail = model.Mail;
                model.Password = model.Password;
                model.Ind_User = model.Ind_User;
                model.Points = model.Points;
                model.ID_Person = person.ID_Person;
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.PersonController.ActionResult_Index" + ex.Message);
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
                        var person = db.Persons.Find(model.ID_Person);
                        person.Identification = model.Identification;
                        person.Name = model.Name;
                        person.Mail = model.Mail;
                        person.Password = model.Password;
                        person.Ind_User = model.Ind_User;
                        person.Points = model.Points;

                        db.Entry(person).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        
                    }

                    return Redirect("~/Person/");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ServicesMVC_Direct.PersonController.ActionResult_Edit(TablaViewModel model)" + ex.Message);

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
                var person = db.Persons.Find(id);
                db.Persons.Remove(person);
                db.SaveChanges();
              
                }
                catch (Exception ex)
                {

                    Console.WriteLine("ServicesMVC_Direct.PersonController.ActionResult_Delete" + ex.Message);
                    
                }


            }
            return Redirect("~/Person/");
        }
    }
 }
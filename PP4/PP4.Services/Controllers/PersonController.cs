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
                 lst = (from d in db.Persons
                           select new ListPersonViewModel
                           {
                               Identification = d.Identification,
                               Name = d.Name,
                               Mail = d.Mail,
                               Points = d.Points


                           }).ToList();
                
            }
            return View(lst);

        }

        public ActionResult Nuevo()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    using (DBContextCF db = new DBContextCF()) 
                    {
                        
                        var person = new Person();
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
                throw new Exception(ex.Message);

            }
          

          
        }
    }
 }
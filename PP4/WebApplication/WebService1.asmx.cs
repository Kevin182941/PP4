using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using PP4.BL;
using PP4.DAL;




namespace WebApplication
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public void AddPerson(string Identification,string Name,string Mail,string Password)
        {
            Data_People data_People = new Data_People();
            Person person = new Person();
            person.Identification = Identification;
            person.Name = Name;
            person.Mail = Mail;
            person.Password = Password;
            person.Points = 10;
            person.Ind_User = true;           
            
            data_People.Insert(person);

        }

        [WebMethod]
        public void DeletePerson(int id)
        {
            Data_People data_People = new Data_People();          
            data_People.Delete(id);
        }


        [WebMethod]
        public void UpdatePerson(int id,string Identification, string Name, string Mail, string Password)
        {
            Data_People data_People = new Data_People();
            Person person = new Person();
            person.ID_Person = id;
            person.Identification = Identification;
            person.Name = Name;
            person.Mail = Mail;
            person.Password = Password;
            person.Points = 10;
            person.Ind_User = true;
            data_People.Update(person);
        }

        [WebMethod]
        public Person GetPerson(int id)
        {
            Data_People data_People = new Data_People();

            var person = data_People.GetrById(id);

            return person;
        }
    }
}

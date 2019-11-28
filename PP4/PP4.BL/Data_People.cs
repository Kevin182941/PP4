using PP4.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.BL
{
    public class Data_People : IRepositorio<Person>
    {

        #region CRUD People

        public void Delete(int IDPerson)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Persons.Where(x => x.ID_Person == IDPerson).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Persons.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
        }

        public IEnumerable Get()
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Persons.ToList();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
            return null;
        }

        public Person GetrById(int IDPerson)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Persons.Where(x => x.ID_Person == IDPerson).SingleOrDefault();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
            return null;
        }

        public void Insert(Person item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Persons.Add(item);
                    context.SaveChanges();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
        }

        public void Update(Person item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Entry(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

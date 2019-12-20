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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_People.Delete" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_People.Ienumerable_Get" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_People.Person_GetrById" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_People.Insert" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_People.Update" + ex.Message);

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

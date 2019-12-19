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
    public class Data_Schedule : IRepositorio<Schedule>
    {


        #region CRUD Schedule 

        public void Delete(int IDSchedule)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Schedules.Where(x => x.ID_Schedule == IDSchedule).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Schedules.Remove(toDelete);
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
                    return context.Schedules.ToList();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
            return null;
        }

        public Schedule GetrById(int IDSchedule)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Schedules.Where(x => x.ID_Schedule == IDSchedule).SingleOrDefault();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
            return null;
        }

        public void Insert(Schedule item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Schedules.Add(item);
                    context.SaveChanges();
                }
                catch
                {
                    //Mensaje de Error;

                }
            }
        }

      

        public void Update(Schedule item)
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



        #endregion CRUD Schedule 

    }
}

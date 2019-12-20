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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Schedule.Delete" + ex.Message);


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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Schedule.IEnumerable" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Schedule.Schedule_GetrById" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Schedule.Insert" + ex.Message);

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
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Schedule.Update" + ex.Message);

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

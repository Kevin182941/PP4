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
    public class Data_Seat : IRepositorio<Seat>
    {
        public void Delete(int IDSeat)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Seats.Where(x => x.ID_Seat == IDSeat).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Seats.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Seat.Delete" + ex.Message);


                }
            }
        }

        public IEnumerable Get()
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Seats.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Seat.IEnumerable_Get" + ex.Message);

                }
            }
            return null;
        }

        public Seat GetrById(int IDSeat)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Seats.Where(x => x.ID_Seat == IDSeat).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Seat.Seat_GetrById" + ex.Message);

                }
            }
            return null;
        }

        public void Insert(Seat item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Seats.Add(item);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Seat.Insert" + ex.Message);
                }
            }
        }

     

        public void Update(Seat item)
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
                    Console.WriteLine("BL.Data_Seat.Update" + ex.Message);

                }
            }
        }

        public void save()
        {
            throw new NotImplementedException();
        }
    }
}

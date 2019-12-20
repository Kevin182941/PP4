using PP4.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PP4.BL
{
    public class Data_Purchase : IRepositorio<Purchase>
    {
        public void Delete(int IDPurchase)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Purchases.Where(x => x.ID_Purchase == IDPurchase).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Purchases.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch
                {
                    Console.WriteLine("BL.Data_Purchase.Delete" + ex.Message);

                }
            }
        }

        public IEnumerable Get()
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var ListPurchase = (from P in context.Purchases
                                        join F in context.Persons on P.ID_Person equals F.ID_Person
                                        join B in context.Batches on P.ID_Batch equals B.ID_Batch
                                        join M in context.Movies on B.ID_Movie equals M.ID_Movie
                                        join S in context.Schedules on B.ID_Schedule equals S.ID_Schedule
                                        join R in context.Rooms on B.ID_Room equals R.ID_Room
                                        join A in context.Seats on R.ID_Room equals A.ID_Room

                                        select new
                                        {
                                            P.ID_Purchase,
                                            P.ID_Person,
                                            F.Name,
                                            B.ID_Movie,
                                            M.Description_Movie,
                                            S.Day,
                                            B.ID_Room,
                                            R.Description,
                                            P.Date_Purchase,
                                            A.Row,
                                            A.Number,
                                            A.Price
                                        } into x
                                        group x by x.ID_Purchase into g
                                        select g);

                          
                    return ListPurchase;
                }
                catch
                {
                    Console.WriteLine("BL.Data_Purchase.IEnumerable Get" + ex.Message);

                }
            }
            return null;
        }

        public Purchase GetrById(int IDPurchase)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var ListPurchase = (from P in context.Purchases
                                        join F in context.Persons on P.ID_Person equals F.ID_Person
                                        join B in context.Batches on P.ID_Batch equals B.ID_Batch
                                        join M in context.Movies on B.ID_Movie equals M.ID_Movie
                                        join S in context.Schedules on B.ID_Schedule equals S.ID_Schedule
                                        join R in context.Rooms on B.ID_Room equals R.ID_Room
                                        join A in context.Seats on R.ID_Room equals A.ID_Room
                                        where P.ID_Purchase == IDPurchase
                                        select new
                                        {
                                            ID_Purchase = P.ID_Purchase,
                                            ID_Person = P.ID_Person,
                                            Name = F.Name,
                                            ID_Movie = B.ID_Movie,
                                            Description_Movie = M.Description_Movie,
                                            Day = S.Day,
                                            ID_Room = B.ID_Room,
                                            Description = R.Description,
                                            Date_Purchase = P.Date_Purchase,
                                            Row = A.Row,
                                            Number= A.Number,
                                            Price = A.Price
                                        } ).FirstOrDefault();
 
                    
                }
                catch
                {
                    Console.WriteLine("BL.Data_Purchase.Purchase_GetrById" + ex.Message);

                }
            }
            return null;
        }

        public void Insert(Purchase item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Purchases.Add(item);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("BL.Data_Purchase.Insert" + ex.Message);

                }
            }
        }

        public void Update(Purchase item)
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
                    Console.WriteLine("BL.Data_Purchase.Update" + ex.Message);

                }
            }
        }

        public void save()
        {
            throw new NotImplementedException();
        }

    }
}

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
    class Data_Batch : IRepositorio<Batch>
    {
        #region CRUD Room

        public void Delete(int IDBatch)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Batches.Where(x => x.ID_Batch == IDBatch).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Batches.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Batch.Delete" + ex.Message);

                }
            }
        }

        public IEnumerable Get()
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Batches.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Batch.IEnumerable_Get" + ex.Message);

                }
            }
            return null;
        }

        public Batch GetrById(int IDBatch)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Batches.Where(x => x.ID_Batch == IDBatch).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Batch.Batch_GetrById" + ex.Message);


                }
            }
            return null;
        }

        public void Insert(Batch item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Batches.Add(item);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Batch.Insert" + ex.Message);

                }
            }
        }

      

        public void Update(Batch item)
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
                    Console.WriteLine("BL.Data_Batch.Update" + ex.Message);

                }
            }
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        #endregion CRUD Room
    }
}

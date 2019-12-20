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
    public class Data_Room : IRepositorio<Room>
    {

        #region CRUD Room

        public void Delete(int IDRoom)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Rooms.Where(x => x.ID_Room == IDRoom).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Rooms.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch
                {
                    Console.WriteLine("BL.Data_Room.Delete" + ex.Message);

                }
            }
        }


        public IEnumerable Get()
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Rooms.ToList();
                }
                catch
                {
                    Console.WriteLine("BL.Data_Room.IEnumerable_Get" + ex.Message);

                }
            }
            return null;
        }




        public Room GetrById(int IDRoom)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Rooms.Where(x => x.ID_Room == IDRoom).SingleOrDefault();
                }
                catch
                {
                    Console.WriteLine("BL.Data_Room.Room_GetrById" + ex.Message);

                }
            }
            return null;
        }


        public void Insert(Room item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Rooms.Add(item);
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("BL.Data_Room.Insert" + ex.Message);

                }
            }
        }

        public void Update(Room item)
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
                    Console.WriteLine("BL.Data_Room.Update" + ex.Message);

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


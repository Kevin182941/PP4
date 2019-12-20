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
    class Data_Movies : IRepositorio<Movie>
    {

        #region CRUD Movies

        public void Delete(int IDMovie)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    var toDelete = context.Movies.Where(x => x.ID_Movie == IDMovie).SingleOrDefault();
                    if (toDelete != null)
                    {
                        context.Movies.Remove(toDelete);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Movies.Delete" + ex.Message);

                }
            }
        }

        public IEnumerable Get()
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Movies.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Movies.IEnumerable_Get" + ex.Message);

                }
            }
            return null;
        }

        public Movie GetrById(int IDMovie)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    return context.Movies.Where(x => x.ID_Movie == IDMovie).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Movies.GetrById" + ex.Message);

                }
            }
            return null;
        }

        public void Insert(Movie item)
        {
            using (DBContextCF context = new DBContextCF())
            {
                try
                {
                    context.Movies.Add(item);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("BL.Data_Movies.Insert" + ex.Message);

                }
            }
        }

        public void Update(Movie item)
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
                    Console.WriteLine("BL.Data_Movies.Update" + ex.Message);

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

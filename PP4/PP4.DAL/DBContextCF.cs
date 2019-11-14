
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    public class DBContextCF : DbContext
    {

        public DBContextCF()

            : base("name=CFPP4")
        {

        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Seat> Asientos { get; set; }

        public DbSet<Room> Salas { get; set; }

        public DbSet<Schedule> Horarios { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Movie> Peliculas { get; set; }

    }
}

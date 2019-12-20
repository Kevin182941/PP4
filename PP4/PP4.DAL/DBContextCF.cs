
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Purchase_Seat> Purchase_Seats { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Batch> Batches { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Movie> Movies { get; set; }

        


    }
}

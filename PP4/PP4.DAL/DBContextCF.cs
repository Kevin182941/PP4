
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

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Schedule_Room_Movie> Schedule_Rooms { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Purchase_Seat> Purchase_Seats { get; set; }

        public DbSet<Movie> Movies { get; set; }


    }
}

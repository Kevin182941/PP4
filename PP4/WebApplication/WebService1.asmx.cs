using System;
using System.Collections.Generic;
using System.Linq;


namespace WebApplication
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        ////////////////////////////////////////////Person////////////////////////////////////////////////////////////



        [WebMethod]
        public Person AddPerson(string Identification, string Name, string Mail, string Password, int points, bool state)
        {
            Data_People data_People = new Data_People();
            Person person = new Person();
            person.Identification = Identification;
            person.Name = Name;
            person.Mail = Mail;
            person.Password = Password;
            person.Points = points;
            person.Ind_User = state;

            data_People.Insert(person);


            return person;

        }

        [WebMethod]
        public void DeletePerson(int id)
        {
            Data_People data_People = new Data_People();
            data_People.Delete(id);
        }


        [WebMethod]
        public void UpdatePerson(int id, string Identification, string Name, string Mail, string Password, int points, bool state)
        {
            Data_People data_People = new Data_People();
            Person person = new Person();
            person.ID_Person = id;
            person.Identification = Identification;
            person.Name = Name;
            person.Mail = Mail;
            person.Password = Password;
            person.Points = points;
            person.Ind_User = state;
            data_People.Update(person);
        }

        [WebMethod]
        public Person GetPerson(int id)
        {
            Data_People data_People = new Data_People();
            var person = data_People.GetrById(id);
            return person;

        }

        [WebMethod]
        public List<Person> GetAllPeople()
        {
            using (DBContextCF context = new DBContextCF())
            {
                var person = context.Persons.ToList();
                return person;
            }

        }


        ////////////////////////////////////////////ROOM////////////////////////////////////////////////////////////

        [WebMethod]
        public Room AddRoom(string Description, int Capacity, bool State)
        {
            Data_Room data_Room = new Data_Room();
            Room room = new Room();
            room.Description = Description;
            room.Capacity = Capacity;
            room.State = State;


            data_Room.Insert(room);


            return room;

        }

        [WebMethod]
        public void UpdateRoom(int ID_Room, string Description, int Capacity, bool State)
        {
            Data_Room data_Room = new Data_Room();
            Room room = new Room();
            room.ID_Room = ID_Room;
            room.Description = Description;
            room.Capacity = Capacity;
            room.State = State;
            data_Room.Update(room);
        }


        [WebMethod]
        public void DeleteRoom(int id)
        {
            Data_Room data_Room = new Data_Room();
            data_Room.Delete(id);
        }

        [WebMethod]
        public Room GetRoom(int id)
        {
            Data_Room data_Room = new Data_Room();
            var room = data_Room.GetrById(id);
            return room;

        }

        [WebMethod]
        public List<Room> GetAllRooms()
        {
            using (DBContextCF context = new DBContextCF())
            {
                var room = context.Rooms.ToList();
                return room;
            }

        }

        ////////////////////////////////////////////Schedule////////////////////////////////////////////////////////////

        [WebMethod]
        public Schedule AddSchedule(DateTime Day, bool State)
        {
            Data_Schedule data_Schedule = new Data_Schedule();
            Schedule schedule = new Schedule();
            schedule.Day = Day;
            schedule.State = State;


            data_Schedule.Insert(schedule);


            return schedule;

        }

        [WebMethod]
        public void UpdateSchedule(int ID_Schedule, DateTime Day, bool State)
        {
            Data_Schedule data_Schedule = new Data_Schedule();
            Schedule schedule = new Schedule();
            schedule.ID_Schedule = ID_Schedule;
            schedule.Day = Day;
            schedule.State = State;
            data_Schedule.Update(schedule);
        }


        [WebMethod]
        public void DeleteSchedule(int id)
        {
            Data_Schedule data_Schedule = new Data_Schedule();
            data_Schedule.Delete(id);
        }

        [WebMethod]
        public Schedule GetSchedule(int id)
        {
            Data_Schedule data_Schedule = new Data_Schedule();
            var schedule = data_Schedule.GetrById(id);
            return schedule;

        }

        [WebMethod]
        public List<Schedule> GetAllSchedules()
        {
            using (DBContextCF context = new DBContextCF())
            {
                var schedule = context.Schedules.ToList();
                return schedule;
            }

        }


        ////////////////////////////////////////////Seat////////////////////////////////////////////////////////////


        [WebMethod]
        public Seat AddSeat(int ID_Room, string Description_Seat, string Row, int Number, decimal Price)
        {
            Data_Seat data_Seat = new Data_Seat();
            Seat seat = new Seat();
            seat.ID_Room = ID_Room;
            seat.Description_Seat = Description_Seat;
            seat.Row = Row;
            seat.Number = Number;
            seat.Price = Price;


            data_Seat.Insert(seat);


            return seat;
        }

        [WebMethod]
        public void UpdateSeat(int ID_Seat, int ID_Room, string Description_Seat, string Row, int Number, decimal Price)
        {
            Data_Seat data_Seat = new Data_Seat();
            Seat seat = new Seat();
            seat.ID_Seat = ID_Seat;
            seat.ID_Room = ID_Room;
            seat.Description_Seat = Description_Seat;
            seat.Row = Row;
            seat.Number = Number;
            seat.Price = Price;

            data_Seat.Update(seat);
        }


        [WebMethod]
        public void DeleteSeat(int id)
        {
            Data_Seat data_Seat = new Data_Seat();
            data_Seat.Delete(id);
        }

        [WebMethod]
        public Seat GetSeat(int id)
        {
            Data_Seat data_Seat = new Data_Seat();
            var seat = data_Seat.GetrById(id);
            return seat;

        }

        [WebMethod]
        public List<Seat> GetAllSeats()
        {
            using (DBContextCF context = new DBContextCF())
            {
                var seat = context.Seats.ToList();
                return seat;
            }

        }

        ////////////////////////////////////////////Purchase////////////////////////////////////////////////////////////

        [WebMethod]
        public Purchase AddPurchase(int ID_Batch, int ID_Person, DateTime Date_Purchase)
        {
            Data_Purchase data_Purchase = new Data_Purchase();
            Purchase purchase = new Purchase();
            purchase.ID_Batch = ID_Batch;
            purchase.ID_Person = ID_Person;
            purchase.Date_Purchase = Date_Purchase;


            data_Purchase.Insert(purchase);


            return purchase;
        }

        [WebMethod]
        public void UpdatePurchase(int ID_Purchase, int ID_Batch, int ID_Person, DateTime Date_Purchase)
        {
            Data_Purchase data_Purchase = new Data_Purchase();
            Purchase purchase = new Purchase();
            purchase.ID_Purchase = ID_Purchase;
            purchase.ID_Batch = ID_Batch;
            purchase.ID_Person = ID_Person;
            purchase.Date_Purchase = Date_Purchase;


            data_Purchase.Update(purchase);
        }


        [WebMethod]
        public void DeletePurchase(int id)
        {
            Data_Purchase data_Purchase = new Data_Purchase();
            data_Purchase.Delete(id);
        }

        [WebMethod]
        public Purchase GetPurchase(int id)
        {
            Data_Purchase data_Purchase = new Data_Purchase();
            var purchase = data_Purchase.GetrById(id);
            return purchase;

        }

        [WebMethod]
        public List<Purchase> GetAllPurchases()
        {
            using (DBContextCF context = new DBContextCF())
            {
                var purchase = context.Purchases.ToList();
                return purchase;
            }

        }

        ////////////////////////////////////////////Movie////////////////////////////////////////////////////////////


        [WebMethod]
        public Movie AddMovie(int ID_Movie, string Description_Movie, int Duration, bool State)
        {
            Data_Movies data_Movies = new Data_Movies();
            var movie = new Movie();
            movie.ID_Movie = ID_Movie;
            movie.Description_Movie = Description_Movie;
            movie.Duration = Duration;
            movie.State = State;

            data_Movies.Insert(movie);


            return movie;

        }

        [WebMethod]
        public void DeleteMovie(int id)
        {
            Data_Movies data_Movies = new Data_Movies();
            data_Movies.Delete(id);
        }


        [WebMethod]
        public void UpdateMovie(int ID_Movie, string Description_Movie, int Duration, bool State)
        {
            Data_Movies data_Movies = new Data_Movies();
            var movie = new Movie();
            movie.ID_Movie = ID_Movie;
            movie.Description_Movie = Description_Movie;
            movie.Duration = Duration;
            movie.State = State;

            data_Movies.Update(movie);

        }

        [WebMethod]
        public Movie GetMovie(int id)
        {
            Data_Movies data_Movies = new Data_Movies();
            var movie = data_Movies.GetrById(id);
            return movie;

        }

        [WebMethod]
        public List<Movie> GetAllMovies()
        {
            using (DBContextCF context = new DBContextCF())
            {
                var movie = context.Movies.ToList();
                return movie;
            }

        }
        ////////////////////////////////////////////BATCH////////////////////////////////////////////////////////////
        [WebMethod]
        public Batch AddBatch(int ID_Room, int ID_Schedule, int ID_Movie)
        {
            Data_Batch data_Batch = new Data_Batch();
            var batch = new Batch();
            // batch.ID_Batch = ID_Batch;
            batch.ID_Room = ID_Room;
            batch.ID_Schedule = ID_Schedule;
            batch.ID_Movie = ID_Movie;

            data_Batch.Insert(batch);


            return batch;

        }
        [WebMethod]
        public void DeleteBatch(int id)
        {
            Data_Batch data_Batch = new Data_Batch();
            data_Batch.Delete(id);
        }
        [WebMethod]
        public void UpdateBatch(int ID_Room, int ID_Schedule, int ID_Movie)
        {
            Data_Batch data_Batch = new Data_Batch();
            var batch = new Batch();
            batch.ID_Room = ID_Room;
            batch.ID_Schedule = ID_Schedule;
            batch.ID_Movie = ID_Movie;

            data_Batch.Update(batch);

        }

        [WebMethod]
        public Batch GetBatch(int id)
        {
            Data_Batch data_Batch = new Data_Batch();
            var batch = data_Batch.GetrById(id);
            return batch;

        }

        [WebMethod]
        public List<Batch> GetAllBatch()
        {
            // consulta desd una bd
            using (DBContextCF context = new DBContextCF())
            {
                var batch = context.Batch.ToList();
                return batch;
            }

        }

    }

}

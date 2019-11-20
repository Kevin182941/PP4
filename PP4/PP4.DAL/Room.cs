using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    public class Room
    {
        [Key]
        public int ID_Room { get; set; }

        public int Capacity { get; set; }

        public bool State { get; set; }


        public virtual ICollection<Seat> Seats { get; set; }
        
        public virtual Schedule_Room_Movie Schedule_Room_Movie { get; set; }
    }
}

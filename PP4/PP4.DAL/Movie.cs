using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    public class Movie
    {
        [Key]
        public int ID_Movie { get; set; }

        public string Tittle { get; set; }

        public int Duration { get; set; }

        public virtual Schedule_Room_Movie  Schedule_Room_Movie { get; set; }
    }
}

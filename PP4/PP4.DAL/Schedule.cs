using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Schedule
    {
        [Key]
        public int ID_Schedule { get; set; }

        public int ID_Movie { get; set; }
        [ForeignKey("ID_Movie")]
        [XmlIgnore]
        public virtual ICollection<Movie> Movies { get; set; }

        public int ID_Room { get; set; }
        [ForeignKey("ID_Room")]
        [XmlIgnore]
        public virtual ICollection<Room> Rooms { get; set; }

        public int Day { get; set; }

        public int Hour { get; set; }

        [XmlIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Batch
    {
        #region Attribute
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Batch { get; set; }

        public int ID_Room { get; set; }
        [ForeignKey("ID_Room")]
        [XmlIgnore]
        public virtual ICollection<Room> Rooms { get; set; }

        public int ID_Schedule { get; set; }
        [ForeignKey("ID_Schedule")]
        [XmlIgnore]
        public virtual ICollection<Schedule> Schedules { get; set; }

        public int ID_Movie { get; set; }
        [ForeignKey("ID_Movie")]
        [XmlIgnore]
        public virtual ICollection<Movie> Movies { get; set; }

        #endregion

        

    }
}

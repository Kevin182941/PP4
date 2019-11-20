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
    public class Purchase
    {
        [Key]
        public int ID_Purchase { get; set; }

        
        public int ID_Person { get; set; }
        [ForeignKey("ID_Person")]
        public virtual Person Person { get; set; }

        
        public int ID_Schedule_Room_Movie { get; set; }
        [ForeignKey("ID_Schedule_Room_Movie")]
        public virtual Schedule_Room_Movie Schedule_Room_Movie { get; set; }

        [XmlIgnore]
        public virtual ICollection<Purchase_Seat> Purchase_Seats { get; set; }




    }
}

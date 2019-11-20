using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Seat
    {

        [Key]
        public int ID_Seat { get; set; }

        
        public int ID_Room { get; set; }
        [ForeignKey("ID_Room")]

        public virtual Room Room { get; set; }

        public string Row { get; set; }

        public int Number { get; set; }

        public decimal Price { get; set; }

        [XmlIgnore]
        public virtual ICollection<Purchase_Seat> Purchase_Seats { get; set; }

    }
}

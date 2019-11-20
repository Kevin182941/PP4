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
    public class Purchase_Seat
    {
        [Key]
        public int ID_Deta { get; set; }

        public int ID_Purchase { get; set; }
        [ForeignKey("ID_Purchase")]
        public virtual Purchase Purchase { get; set; }

        public int ID_Seat { get; set; }
        [ForeignKey("ID_Seat")]
        public virtual Seat Seat { get; set; }
    }
}

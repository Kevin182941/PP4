using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    public class Purchase
    {
        [Key]
        [Column(Order = 1)]
        public int ID_Purchase { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ID_Person { get; set; }
        [ForeignKey("ID_Person")]
        public virtual Person Person { get; set; }


        [Key]
        [Column(Order = 3)]
        public int ID_Schedule { get; set; }
        [ForeignKey("ID_Schedule")]
        public virtual Schedule Schedule { get; set; }


        [Key]
        [Column(Order = 4)]
        public int ID_Seat { get; set; }
        [ForeignKey("ID_Seat")]
        public virtual Seat Seat { get; set; }
        







    }
}

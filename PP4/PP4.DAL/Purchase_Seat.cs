using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Purchase_Seat
    {
        #region Attribute

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Purchase_Seat { get; set; }

        public int ID_Purchase { get; set; }
        [ForeignKey("ID_Purchase")]
        [XmlIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }

        public int ID_Seat { get; set; }
        [ForeignKey("ID_Seat")]
        [XmlIgnore]
        public virtual ICollection<Seat> Seats { get; set; }


        public virtual Person Person { get; set; }

        #endregion




    }
}
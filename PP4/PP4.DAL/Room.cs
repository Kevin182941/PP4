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
    public class Room
    {
        #region Attribute

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Room { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public bool State { get; set; }
        #endregion

        #region Relation
        [XmlIgnore]
        public virtual ICollection<Seat> Seats { get; set; }
        
        public virtual Batch Batch { get; set; }

        #endregion
    }
}

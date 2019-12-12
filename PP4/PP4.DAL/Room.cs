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

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Room { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public bool State { get; set; }
        #endregion


        public virtual ICollection<Batch> Batches { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}

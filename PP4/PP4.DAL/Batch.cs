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

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Batch { get; set; }
        
        public int ID_Room { get; set; }
        
        public int ID_Schedule { get; set; }
       
        public int ID_Movie { get; set; }

        #endregion

        [XmlIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}

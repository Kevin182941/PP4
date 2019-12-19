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

    public class Person

    {
        #region Attribute

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    
        public int ID_Person { get; set; }
        
        public string Name { get; set; }

        public string Identification { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public bool Ind_User { get; set; }

        public int Points { get; set; }

        #endregion

        [XmlIgnore]
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
    
}

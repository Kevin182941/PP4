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
    public class Movie
    {
        #region Attribute 

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int ID_Movie { get; set; }

        public string Description_Movie { get; set; }

        public int Duration { get; set; }

        public bool State { get; set; }

        #endregion

        [XmlIgnore]
        public virtual ICollection<Batch> Batches { get; set; }

    }
}

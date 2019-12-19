using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Schedule
    {
        #region Attribute

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int ID_Schedule { get; set; }

        
        public DateTime Day { get; set; }

        public bool State { get; set; }

        #endregion

        [XmlIgnore]
        public virtual ICollection<Batch> Batches { get; set; }

    }

   
}
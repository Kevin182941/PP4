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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Schedule { get; set; }

        public DateTime Day { get; set; }

        public bool State { get; set; }

        #endregion

        #region Relation
        public virtual Batch Batch { get; set; }

        #endregion


    }

   
}
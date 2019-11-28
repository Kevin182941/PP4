using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    public class Movie
    {
        #region Attribute 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Movie { get; set; }

        public string Description_Movie { get; set; }

        public int Duration { get; set; }

        public bool State { get; set; }

        #endregion

        #region Relation
        public virtual Batch Batch { get; set; }

        #endregion

    }
}

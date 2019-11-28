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
    public class Purchase
    {
        #region Attribute

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID_Purchase { get; set; }

        public int ID_Batch { get; set; }
        [ForeignKey("ID_Batch")]
        public virtual Batch Batch { get; set; }


        public int ID_Person { get; set; }
        [ForeignKey("ID_Person")]
        public virtual Person Person { get; set; }

        public DateTime Date_Purchase { get; set; }

        #endregion

    }

      

    }


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Purchase_Seat
    {
        #region Attribute

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Purchase_Seat { get; set; }

        public int ID_Purchase { get; set; }
        
        public int ID_Seat { get; set; }
        
        #endregion

    }
}
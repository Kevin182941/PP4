using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.data.entity;
using System.database;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PP4.Services.MVC_UI.Models.Reporte
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public class ReportDBContextCF : DbContext
    {
        static ReportDBContextCF()
        {
            Database.SetInitializer<ReporteDBContextCF>(null);
        }
        public ReportDBContextCF() : base("Name=ReportDBContextCF")
        {
        }
    }
}
//<>
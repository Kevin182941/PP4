using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E
{
    [Serializable]
    public class CorreoElectronico
    {
        //Atributos
        private string correoDestinatario;
        private string correoRemitente;
        private string asunto;
        private string mensaje;

        public string DESTINATARIO
        {
            get { return this.correoDestinatario; }
            set { this.correoDestinatario = value; }
        }

        public string REMITENTE
        {
            get { return this.correoRemitente; }
            set { this.correoRemitente = value; }
        }

        public string ASUNTO
        {
            get { return this.asunto; }
            set { this.asunto = value; }
        }

        public string MENSAJE
        {
            get { return this.mensaje; }
            set { this.mensaje = value; }
        }

    }
}

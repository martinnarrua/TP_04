using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EJ07
{
    [Serializable]
    public class Calendario
    {
        /// <summary>
        /// Representa el titulo utilizado para reconocer el calendario
        /// </summary>
        private string iTitulo;

        /// <summary>
        /// Representa la fecha de creacion del calendario
        /// </summary>
        private readonly DateTime iFechaCreacion;


        /// <summary>
        /// Representa la fecha de la ultima modificacion del calendario
        /// </summary>
        private DateTime iFechaModificacion;

        public string Titulo
        {
            get { return this.iTitulo; }
            private set { this.iTitulo = value; }
        }
        public DateTime FechaCreacion
        {
            get { return this.iFechaCreacion; }
            private set { this.iFechaCreacion = value; }
        }

        public DateTime FechaModificacion
        {
            get { return this.iFechaModificacion; }
            set { this.iFechaModificacion = value; }
        }


        /// <summary>
        /// Constructor de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pTitulo"></param>
        public Calendario(string pTitulo)
        {
            this.Titulo = pTitulo;
            this.FechaCreacion = DateTime.Now.Date;
        }

        public void Modificar(string pTitulo)
        {
            this.Titulo = pTitulo;
            this.FechaModificacion = DateTime.Now.Date;

        }

        internal Calendario Copiar()
        {
            using (var lMemoryStream = new MemoryStream())
            {
                var lFormatter = new BinaryFormatter();
                lFormatter.Serialize(lMemoryStream, this);
                lMemoryStream.Position = 0;
                return (Calendario) lFormatter.Deserialize(lMemoryStream);
            }
        }
    }
}

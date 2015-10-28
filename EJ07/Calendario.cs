using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07
{
    public class Calendario
    {
        /// <summary>
        /// Representa el titulo utilizado para reconocer el calendario
        /// </summary>
        private string iTitulo;

        /// <summary>
        /// Representa la fecha de creacion del calendario
        /// </summary>
        private DateTime iFechaCreacion;

        /// <summary>
        /// Representa la hora de creacion del calendario
        /// </summary>
        private TimeSpan iHoraCreacion;

        /// <summary>
        /// Representa la fecha de la ultima modificacion del calendario
        /// </summary>
        private DateTime iFechaModificacion;

        /// <summary>
        /// Representa la hora de la ultima modificacion del calendario
        /// </summary>
        private TimeSpan iHoraModificacion;
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
        public TimeSpan HoraCreacion
        {
            get { return this.iHoraCreacion; }
            private set { this.iHoraCreacion = value; }
        }

        public DateTime FechaModificacion
        {
            get { return this.iFechaModificacion; }
            set { this.iFechaModificacion = value; }
        }
        public TimeSpan HoraModificacion
        {
            get { return this.iHoraModificacion; }
            set { this.iHoraModificacion = value; }
        }

        /// <summary>
        /// Constructor de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pTitulo"></param>
        public Calendario(string pTitulo)
        {
            this.Titulo = pTitulo;
            this.FechaCreacion = DateTime.Now.Date;
            this.HoraCreacion = DateTime.Now.TimeOfDay;
        }

        public void Modificar(string pTitulo)
        {
            this.Titulo = pTitulo;
            this.FechaModificacion = DateTime.Now.Date;
            this.HoraModificacion = DateTime.Now.TimeOfDay;
        }
    }
}

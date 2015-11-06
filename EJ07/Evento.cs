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
    /// <summary>
    /// Representa un evento que se almacena en un calendario
    /// </summary>
    public class Evento
    {
        /// <summary>
        /// Representa el codigo del evento
        /// </summary>
        private readonly string iCodigo;

        /// <summary>
        /// Representa el titulo del evento
        /// </summary>
        private string iTitulo;

        /// <summary>
        /// Representa la fecha de creacion del evento
        /// </summary>
        private readonly DateTime iFechaCreacion;

        /// <summary>
        /// Representa la fecha de comienzo del evento
        /// </summary>
        private DateTime iFechaComienzo;

        /// <summary>
        /// Representa la fecha de fin del evento
        /// </summary>
        private DateTime iFechaFin;

        /// <summary>
        /// Representa la fecha de ultima modificacion del evento
        /// </summary>
        private DateTime iFechaModificacion;

        /// <summary>
        /// Representa la frecuencia de repeticion del evento
        /// </summary>
        private FrecuenciaRepeticion iFrecuencia;

        /// <summary>
        /// Propiedad Codigo
        /// </summary>
        public string Codigo
        {
            get { return this.iCodigo; }
        }

        /// <summary>
        /// Propiedad Titulo
        /// </summary>
        public string Titulo
        {
            get { return this.iTitulo; }
            set
            {
                this.FechaModificacion = DateTime.Now;
                this.iTitulo = value;
            }
        }

        /// <summary>
        /// Propiedad FechaComienzo
        /// </summary>
        public DateTime FechaComienzo
        {
            get { return this.iFechaComienzo; }
            set
            {
                this.FechaModificacion = DateTime.Now;
                this.iFechaComienzo = value;
            }
        }

        /// <summary>
        /// Propiedad FechaFin
        /// </summary>
        public DateTime FechaFin
        {
            get { return this.iFechaFin; }
            set
            {
                this.FechaModificacion = DateTime.Now;
                this.iFechaFin = value;
            }
        }

        /// <summary>
        /// Propiedad FechaModificacion
        /// </summary>
        public DateTime FechaModificacion
        {
            get { return this.iFechaModificacion; }
            private set { this.iFechaModificacion = value; }
        }

        /// <summary>
        /// Propiedad FechaCreacion
        /// </summary>
        public DateTime FechaCreacion
        {
            get { return this.iFechaCreacion; }
        }

        /// <summary>
        /// Propiedad Frecuencia
        /// </summary>
        public FrecuenciaRepeticion Frecuencia
        {
            get { return this.iFrecuencia; }
            private set { this.iFrecuencia = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pTitulo">Titulo del evento</param>
        /// <param name="pCodigo">Codigo del evento</param>
        /// <param name="pFechaComienzo">Fecha de comienzo del evento</param>
        /// <param name="pFechaFin">Fecha de fin del evento</param>
        /// <param name="pFrecuencia">Frecuencia de repeticion del evento</param>
        public Evento(string pTitulo,string pCodigo, DateTime pFechaComienzo, DateTime pFechaFin, FrecuenciaRepeticion pFrecuencia)
        {
            this.Titulo = pTitulo;
            this.iCodigo = pCodigo;
            this.iFechaCreacion = DateTime.Now;
            this.FechaComienzo = pFechaComienzo;
            this.FechaFin = pFechaFin;
            this.FechaModificacion = DateTime.Now;
            this.Frecuencia = pFrecuencia;
        }

        /// <summary>
        /// Realiza una copia profunda de <see cref="Evento"/>
        /// </summary>
        /// <returns>Copia profunda de <see cref="Evento"/></returns>
        internal Evento Copiar()
        {
            using (var lMemoryStream = new MemoryStream())
            {
                var lFormatter = new BinaryFormatter();
                lFormatter.Serialize(lMemoryStream, this);
                lMemoryStream.Position = 0;
                return (Evento)lFormatter.Deserialize(lMemoryStream);
            }
        }
    }
}

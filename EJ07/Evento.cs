using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EJ07.Comparers;

namespace EJ07
{

    [Serializable]
    /// <summary>
    /// Representa un evento que se almacena en un calendario
    /// </summary>
    public class Evento : IEquatable<Evento>, IComparable<Evento>
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
            set
            {
                this.FechaModificacion = DateTime.Now;
                this.iFrecuencia = value;
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Evento"/>
        /// </summary>
        /// <param name="pTitulo">Titulo del evento</param>
        /// <param name="pCodigo">Codigo del evento</param>
        /// <param name="pFechaComienzo">Fecha de comienzo del evento</param>
        /// <param name="pFechaFin">Fecha de fin del evento</param>
        /// <param name="pFrecuencia">Frecuencia de repeticion del evento</param>
        public Evento(string pTitulo, string pCodigo, DateTime pFechaComienzo, DateTime pFechaFin, FrecuenciaRepeticion pFrecuencia)
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
        public Evento Copiar()
        {
            using (var lMemoryStream = new MemoryStream())
            {
                var lFormatter = new BinaryFormatter();
                lFormatter.Serialize(lMemoryStream, this);
                lMemoryStream.Position = 0;
                return (Evento)lFormatter.Deserialize(lMemoryStream);
            }
        }



        public override bool Equals(object obj)
        {

            // Si obj es (apunta a) null, falso
            if (Object.ReferenceEquals(null, obj))
            {
                return false;
            }
            // Si obj es (apunta a) this, verdadero
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            Evento lEvento = obj as Evento;
            // Si el casteo con As falla, Falso
            if (lEvento == null)
            {
                return false;
            }


            return (this.Titulo == lEvento.Titulo &&
                    this.Codigo == lEvento.Codigo &&
                    this.FechaCreacion == lEvento.FechaCreacion &&
                    this.FechaComienzo == lEvento.FechaComienzo &&
                    this.FechaFin == lEvento.FechaFin &&
                    this.FechaModificacion == lEvento.FechaModificacion &&
                    this.Frecuencia == lEvento.Frecuencia);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return !Object.ReferenceEquals(null, this) ? this.Codigo.GetHashCode() : 0;
        }

        bool IEquatable<Evento>.Equals(Evento pEvento)
        {
            // Si pEvento es (apunta a) null, falso
            if (Object.ReferenceEquals(null, pEvento))
            {
                return false;
            }

            // Si pEvento es (apunta a) this, verdadero
            if (Object.ReferenceEquals(this, pEvento))
            {
                return true;
            }

            return (this.Titulo == pEvento.Titulo &&
                    this.Codigo == pEvento.Codigo &&
                    this.FechaCreacion == pEvento.FechaCreacion &&
                    this.FechaComienzo == pEvento.FechaComienzo &&
                    this.FechaFin == pEvento.FechaFin &&
                    this.FechaModificacion == pEvento.FechaModificacion &&
                    this.Frecuencia == pEvento.Frecuencia);
        }

        /// <summary>
        /// Implementacion de <see cref="IComparable{T}.CompareTo(T)"/>.
        /// Implementa el ordenamiento por defecto para los objetos de la clase <see cref="Evento"/>
        /// </summary>
        /// <param name="pEvento">Evento a comparar con el actual</param>
        /// <returns>Un entero que indica la posicion en el ordenamiento</returns>
        int IComparable<Evento>.CompareTo(Evento pEvento)
        {
            return (new EventCodeAscendingComparer()).Compare(this, pEvento);
        }
    }
}


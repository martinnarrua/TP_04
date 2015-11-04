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
    public class Evento
    {
        private string iTitulo;

        private DateTime iFechaComienzo;

        private DateTime iFechaFin;

        private DateTime iFechaModificacion;

        private int iDuracion;

        private FrecuenciaRepeticion iFrecuencia;

        public string Titulo
        {
            get { return this.iTitulo; }
            private set { this.iTitulo = value; }
        }

        public DateTime FechaComienzo
        {
            get { return this.iFechaComienzo; }
            private set { this.iFechaComienzo = value; }
        }
        public DateTime FechaFin
        {
            get { return this.iFechaFin; }
            private set { this.iFechaFin = value; }
        }

        public DateTime FechaModificacion
        {
            get { return this.iFechaModificacion; }
            private set { this.iFechaModificacion = value; }
        }

        public int Duracion
        {
            get { return this.iDuracion; }
            private set { this.iDuracion = value; }
        }

        public FrecuenciaRepeticion Frecuencia
        {
            get { return this.iFrecuencia; }
            private set { this.iFrecuencia = value; }
        }

        public Evento(string pTitulo, DateTime pFechaComienzo, int pDuracion, FrecuenciaRepeticion pFrecuencia)
        {
            this.Titulo = pTitulo;
            this.FechaComienzo = pFechaComienzo;
            this.Duracion = pDuracion;
            this.Frecuencia = pFrecuencia;
        }

        public void Modificar(Evento pEvento)
        {
            this.Titulo = pEvento.Titulo;
            this.FechaComienzo = pEvento.FechaComienzo;
            this.FechaModificacion = DateTime.Now;
            this.Duracion = pEvento.Duracion;
            this.Frecuencia = pEvento.Frecuencia;

        }

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

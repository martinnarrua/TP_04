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
        private string iCodigo;

        private string iTitulo;

        private DateTime iFechaComienzo;

        private DateTime iFechaFin;

        private DateTime iFechaModificacion;

        private FrecuenciaRepeticion iFrecuencia;

        public string Codigo
        {
            get { return this.iCodigo; }
            private set { this.iCodigo = value; }
        }
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


        public FrecuenciaRepeticion Frecuencia
        {
            get { return this.iFrecuencia; }
            private set { this.iFrecuencia = value; }
        }

        public Evento(string pTitulo,string pCodigo, DateTime pFechaComienzo, DateTime pFechaFin, FrecuenciaRepeticion pFrecuencia)
        {
            this.Titulo = pTitulo;
            this.Codigo = pCodigo;
            this.FechaComienzo = pFechaComienzo;
            this.FechaFin = pFechaFin;
            this.FechaModificacion = DateTime.Now;
            this.Frecuencia = pFrecuencia;
        }

        public void Modificar(Evento pEvento)
        {
            this.Titulo = pEvento.Titulo;
            this.FechaComienzo = pEvento.FechaComienzo;
            this.FechaFin = pEvento.FechaFin;
            this.FechaModificacion = DateTime.Now;
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

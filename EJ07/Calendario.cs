using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EJ07.Exceptions;

namespace EJ07
{
    [Serializable]
    public class Calendario:IRepositorioEventos
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
        /// Representa la fecha de la ultima modificacion del calendario
        /// </summary>
        private DateTime iFechaModificacion;

        private SortedDictionary<string,Evento> iEventos;

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

        public SortedDictionary<string, Evento> Eventos
        {
            get { return this.iEventos; }
        }


        /// <summary>
        /// Constructor de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pTitulo"></param>
        public Calendario(string pTitulo)
        {
            this.Titulo = pTitulo;
            this.FechaCreacion = DateTime.Now;
        }

        public void Modificar(Calendario pCalendario)
        {
            this.Titulo = pCalendario.Titulo;
            this.FechaModificacion = DateTime.Now;

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

        void IRepositorioEventos.Agregar(Evento pEvento)
        {
            if (pEvento == null)
            {
                throw (new ArgumentNullException("pEvento", "No se pudo agregar el evento, el mismo es invalido"));
            }
            else if (pEvento.Titulo == null)
            {
                throw (new ArgumentNullException("pEvento.Titulo", "No se pudo agregar el evento, el titulo es invalido"));
            }
            else if (pEvento.Titulo == String.Empty)
            {
                throw (new ArgumentException("pEvento.Titulo", "No se pudo agregar el evento, el titulo del mismo esta vacio"));
            }
            else if (this.Eventos.ContainsKey(pEvento.Titulo))
            {
                EventoExistenteException lException = new EventoExistenteException(String.Format("No se pudo agregar el evento, ya existe un evento con el titulo '{0}' en este calendario", pEvento.Titulo));
                throw lException;
            }

            this.Eventos.Add(pEvento.Titulo, pEvento.Copiar());
        }

        void IRepositorioEventos.Actualizar(Evento pEvento, Evento pEventoModificado)
        {

            if (pEvento == null)
            {
                throw (new ArgumentNullException("pEvento", "No se pudo actualizar el evento, el mismo es invalido"));
            }
            else if (pEvento.Titulo == null)
            {
                throw (new ArgumentNullException("pEvento.Titulo", "No se pudo actualizar el evento, el titulo es invalido"));
            }
            else if (pEvento.Titulo == String.Empty)
            {
                throw (new ArgumentException("pEvento.Titulo", "No se pudo actualizar el evento, el titulo del mismo esta vacio"));
            }
            else if (!this.Eventos.ContainsKey(pEvento.Titulo))
            {
                EventoNoEncontradoException lException = new EventoNoEncontradoException(String.Format("No se encontro el evento con el nombre '{0}' en este calendario", pEvento.Titulo));
                throw lException;
            }
            this.Eventos[pEvento.Titulo].Modificar(pEventoModificado);

        }

        void IRepositorioEventos.Eliminar(string pTitulo)
        {
            bool eliminado = false;
            if (this.Eventos.ContainsKey(pTitulo))
            {
                this.Eventos.Remove(pTitulo);
                eliminado = true;
            }
            if (!eliminado)
            {
                EventoNoEncontradoException lException = new EventoNoEncontradoException(String.Format("No se encontro el evento con el nombre '{0}' en este calendario", pCalendario.Titulo));
                throw lException;
            }
        }

        IList<Evento> IRepositorioEventos.ObtenerTodos()
        {
            return this.Eventos.Values.ToList();
        }

        Calendario IRepositorioCalendarios.ObtenerPorNombre(string pNombre)
        {
            if (this.Calendarios.ContainsKey(pNombre))
            {
                return this.Calendarios[pNombre];
            }
            else
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el nombre '{0}'", pCalendario.Titulo));
                throw lException;
            }
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerOrdenadosPor(IComparer<Calendario> pComparador)
        {
            throw new NotImplementedException();
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerPorCriterio(ICriteria<Calendario> pCriterio)
        {
            throw new NotImplementedException();
        }
    }
}

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EJ07.Exceptions;
using EJ07.Criteria;

namespace EJ07
{
    [Serializable]
    public class Calendario : IRepositorioEventos, IEquatable<Calendario>
    {
        /// <summary>
        /// Representa el codigo de un calendario
        /// </summary>
        private readonly string iCodigo;
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

        private SortedDictionary<string,Evento> Eventos { get; }


        /// <summary>
        /// Constructor de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pTitulo"></param>
        public Calendario(string pTitulo, string pCodigo)
        {
            this.Titulo = pTitulo;
            this.iCodigo = pCodigo;
            this.iFechaCreacion = DateTime.Now;
            this.FechaModificacion = DateTime.Now;
        }

        public string Codigo
        {
            get { return this.iCodigo; }
        }
        public string Titulo
        {
            get { return this.iTitulo; }
            set
            {
                this.FechaModificacion = DateTime.Now;
                this.iTitulo = value;
            }
        }

        public DateTime FechaCreacion
        {
            get { return this.iFechaCreacion; }
        }

        public DateTime FechaModificacion
        {
            get { return this.iFechaModificacion; }
            set { this.iFechaModificacion = value; }
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
            this.FechaModificacion = DateTime.Now;
        }

        void IRepositorioEventos.Actualizar(Evento pEvento)
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
            this.Eventos[pEvento.Codigo] = pEvento ;
            this.FechaModificacion = DateTime.Now;
        }

        void IRepositorioEventos.Eliminar(string pCodigo)
        {
            if (pCodigo == null)
            {
                throw new ArgumentNullException("pCodigo", "El codigo ingresado es invalido");
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("pCodigo", "El codigo no puede ser vacio"));
            }
            else if (!(this.Eventos.ContainsKey(pCodigo)))
            {
                EventoNoEncontradoException lException = new EventoNoEncontradoException(String.Format("No se encontro el evento con el codigo '{0}'", pCodigo));
                throw lException;
            }
            this.Eventos.Remove(pCodigo);
            this.FechaModificacion = DateTime.Now;
        }

        IList<Evento> IRepositorioEventos.ObtenerTodos()
        {
            return this.Eventos.Values.ToList();
        }

        Evento IRepositorioEventos.ObtenerPorCodigo(string pCodigo)
        {
            if (pCodigo == null)
            {
                throw new ArgumentNullException("pCodigo", "El codigo ingresado es invalido");
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("pCodigo", "El codigo no puede ser vacio"));
            }
            else if (!(this.Eventos.ContainsKey(pCodigo)))
            {
                EventoNoEncontradoException lException = new EventoNoEncontradoException(String.Format("No se encontro el evento con el codigo '{0}'", pCodigo));
                throw lException;
            }
            return this.Eventos[pCodigo];
        }

        IList<Evento> IRepositorioEventos.ObtenerOrdenadosPor(IComparer<Evento> pComparador)
        {
            throw new NotImplementedException();
        }

        IList<Evento> IRepositorioEventos.ObtenerPorCriterio(ICriteria<Evento> pCriterio)
        {
            throw new NotImplementedException();
        }

        bool IEquatable<Calendario>.Equals(Calendario pCalendario)
        {
            // Si pUsuariopCalendario es (apunta a) null, falso
            if (Object.ReferenceEquals(null, pCalendario))
            {
                return false;
            }

            // Si pCalendario es (apunta a) this, verdadero
            if (Object.ReferenceEquals(this, pCalendario))
            {
                return true;
            }

            return (this.Codigo == pCalendario.Codigo);
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

            Calendario lCalendario = obj as Calendario;
            // Si el casteo con As falla, Falso
            if (lCalendario == null)
            {
                return false;
            }

            // Aplico logica particular, casteando previamente a Calendario
            return (this.Equals(lCalendario));

        }

        
        public override int GetHashCode()
        {
            return !Object.ReferenceEquals(null, this) ? this.Codigo.GetHashCode() : 0;
        }
    }
}
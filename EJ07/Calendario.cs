using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using EJ07.Exceptions;
using EJ07.Criteria;
using EJ07.Comparers;
using EJ07.Helpers;

namespace EJ07
{

    [Serializable]
    /// <summary>
    /// Representa un calendario electronico
    /// </summary>
    public class Calendario : IEquatable<Calendario>, IComparable<Calendario>
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

        /// <summary>
        /// Diccionario que contiene los eventos del calendario
        /// </summary>
        private SortedDictionary<string, Evento> Eventos { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pTitulo">Titulo del Calendario</param>
        /// <param name="pCodigo">Codigo del Calendario</param>
        public Calendario(string pTitulo, string pCodigo)
        {
            this.Titulo = pTitulo;
            this.iCodigo = pCodigo;
            this.Eventos = new SortedDictionary<string, Evento>();
            this.iFechaCreacion = DateTime.Now;
            this.FechaModificacion = DateTime.Now;
        }

        /// <summary>
        /// Constructor privado de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pTitulo">Titulo del Calendario</param>
        /// <param name="pCodigo">Codigo del Calendario</param>
        /// <param name="pFechaCreacion">Fecha de Creacion del Calendario</param>
        /// <param name="pFechaModificacion">Fecha de Modificacion del Calendario</param>
        /// <param name="pEventos">Eventos contenidos en el Calendario</param>
        private Calendario(string pTitulo, string pCodigo, DateTime pFechaCreacion, DateTime pFechaModificacion, SortedDictionary<string, Evento> pEventos)
        {
            this.Titulo = pTitulo;
            this.iCodigo = pCodigo;
            this.Eventos = pEventos;
            this.iFechaCreacion = pFechaCreacion;
            this.iFechaModificacion = pFechaModificacion;
        }


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
        /// Propiedad FechaCreacion
        /// </summary>
        public DateTime FechaCreacion
        {
            get { return this.iFechaCreacion; }
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
        /// Realiza una copia profunda de <see cref="Calendario"/>
        /// </summary>
        /// <returns>Copia profunda de <see cref="Calendario"/></returns>
        public Calendario Copiar()
        {
            SortedDictionary<string, Evento> lDiccionario = new SortedDictionary<string, Evento>();

            foreach (KeyValuePair<string, Evento> kpv in this.Eventos)
            {
                lDiccionario.Add(kpv.Key, kpv.Value);
            }

            return  new Calendario(this.iTitulo, this.iCodigo, this.iFechaCreacion, this.iFechaModificacion, lDiccionario);
        }

        /// <summary>
        /// Agregar un <see cref="Evento"/> al Calendario
        /// </summary>
        /// <param name="pEvento">Evento a agregar</param>
        /// <exception cref="ArgumentNullException">Si el evento, el titulo o el codigo es null</exception>
        /// <exception cref="ArgumentException">si el titulo o el codigo es el string vacio</exception>
        /// <exception cref="EventoExistenteException">si el evento ya existe en el calendario</exception>
        public void Agregar(Evento pEvento)
        {
            if (pEvento == null)
            {
                throw (new ArgumentNullException("pEvento", "No se pudo agregar el evento, el mismo es invalido"));
            }
            else if (pEvento.Titulo == null)
            {
                throw (new ArgumentNullException("pEvento.Titulo", "No se pudo agregar el evento, el titulo es invalido"));
            }
            else if (pEvento.Codigo == null)
            {
                throw (new ArgumentNullException("pEvento.Codigo", "No se pudo agregar el evento, el codigo es invalido"));
            }
            else if (pEvento.Titulo == String.Empty)
            {
                throw (new ArgumentException("pEvento.Titulo", "No se pudo agregar el evento, el titulo del mismo esta vacio"));
            }
            else if (pEvento.Codigo == String.Empty)
            {
                throw (new ArgumentException("pEvento.Codigo", "No se pudo agregar el evento, el codigo del mismo esta vacio"));
            }
            else if (this.Eventos.ContainsKey(pEvento.Codigo))
            {
                EventoExistenteException lException = new EventoExistenteException(String.Format("No se pudo agregar el evento, ya existe un evento con el codigo '{0}' en este calendario", pEvento.Codigo));
                throw lException;
            }

            this.Eventos.Add(pEvento.Codigo, pEvento.Copiar());
            this.FechaModificacion = DateTime.Now;
        }

        /// <summary>
        /// Actualiza la informacion de un <see cref="Evento"/> 
        /// </summary>
        /// <param name="pEvento">Evento a actualizar</param>
        /// <exception cref="ArgumentNullException">Si el evento, el titulo o el codigo es null</exception>
        /// <exception cref="ArgumentException">si el titulo o el codigo es el string vacio</exception>
        /// <exception cref="EventoNoEncontradoException">si el evento no existe en el calendario</exception>
        public void Actualizar(Evento pEvento)
        {
            if (pEvento == null)
            {
                throw (new ArgumentNullException("pEvento", "No se pudo actualizar el evento, el mismo es invalido"));
            }
            else if (pEvento.Titulo == null)
            {
                throw (new ArgumentNullException("pEvento.Titulo", "No se pudo actualizar el evento, el titulo es invalido"));
            }
            else if (pEvento.Codigo == null)
            {
                throw (new ArgumentNullException("pEvento.Codigo", "No se pudo actualizar el evento, el codigo es invalido"));
            }
            else if (pEvento.Titulo == String.Empty)
            {
                throw (new ArgumentException("pEvento.Titulo", "No se pudo actualizar el evento, el titulo del mismo esta vacio"));
            }
            else if (pEvento.Codigo == String.Empty)
            {
                throw (new ArgumentException("pEvento.Codigo", "No se pudo actualizar el evento, el codigo del mismo esta vacio"));
            }
            else if (!this.Eventos.ContainsKey(pEvento.Codigo))
            {
                EventoNoEncontradoException lException = new EventoNoEncontradoException(String.Format("No se encontro el evento con el codigo '{0}' en este calendario", pEvento.Codigo));
                throw lException;
            }
            this.Eventos[pEvento.Codigo] = pEvento ;
            this.FechaModificacion = DateTime.Now;
        }

        /// <summary>
        /// Elimina un <see cref="Evento"/> del Calendario
        /// </summary>
        /// <param name="pCodigo">Codigo del usuario a Eliminar</param>
        /// <exception cref="ArgumentNullException">Si el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="UsuarioNoEncontradoException">si el usuario no existe en el repositorio</exception>
        public void Eliminar(string pCodigo)
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

        /// <summary>
        /// Obtiene todos las instancias de <see cref="Evento"/> contenidas en el calendario
        /// </summary>
        /// <returns>Lista de todos los eventos</returns>
        public IList<Evento> ObtenerTodos()
        {
            return this.Eventos.Values.ToList();
        }

        /// <summary>
        /// Permite obtener la instancia de <see cref="Evento"/> cuyo codigo es igual a <paramref name="pCodigo"/>
        /// </summary>
        /// <param name="pCodigo">Codigo del evento que se desea obtener</param>
        /// <returns>El evento buscando en caso de encontrarlo</returns>
        /// <exception cref="ArgumentNullException">Si el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="EventoNoEncontradoException">si el evento no existe en el calendario</exception>
        public Evento ObtenerPorCodigo(string pCodigo)
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

        /// <summary>
        /// Obtiene ordenadas las instancias de <see cref="Evento"/> contenidas en el calendario
        /// </summary>
        /// <param name="pComparador">Implementador de <see cref="IComparer{Evento}"/>, el cual define el criterio del ordenamiento</param>
        /// <returns>Lista de todos los eventos ordenados</returns>
        public IList<Evento> ObtenerOrdenadosPor(IComparer<Evento> pComparador)
        {
            List<Evento> lLista = (List<Evento>)this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCriterio"></param>
        /// <returns></returns>
        public IList<Evento> ObtenerPorCriterio(ICriteria<Evento> pCriterio)
        {
            return pCriterio.SatisfacenCriterio(this.ObtenerSinOrdenar());
        }

        /// <summary>
        /// Permite obtener una lista de todos los <see cref="Evento"/>, sin ordenar
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        private IList<Evento> ObtenerSinOrdenar()
        {
            List<Evento> lLista = this.Eventos.Values.ToList();
            return lLista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCalendario"></param>
        /// <returns></returns>
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

            bool lCamposIguales = (this.Codigo == pCalendario.Codigo &&
                    this.FechaCreacion == pCalendario.FechaCreacion &&
                    this.FechaModificacion == pCalendario.FechaModificacion);


            return lCamposIguales && this.Eventos.EsIgual(pCalendario.Eventos);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
            bool lCamposIguales = (this.Codigo == lCalendario.Codigo &&
                    this.FechaCreacion == lCalendario.FechaCreacion &&
                    this.FechaModificacion == lCalendario.FechaModificacion);


            return lCamposIguales && this.Eventos.EsIgual(lCalendario.Eventos);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return !Object.ReferenceEquals(null, this) ? this.Codigo.GetHashCode() : 0;
        }


        /// <summary>
        /// Implementacion de <see cref="IComparable{T}.CompareTo(T)"/>.
        /// Implementa el ordenamiento por defecto para los objetos de la clase <see cref="Calendario"/>
        /// </summary>
        /// <param name="pCalendario">Calendario a comparar con el actual</param>
        /// <returns>Un entero que indica la posicion en el ordenamiento</returns>
        int IComparable<Calendario>.CompareTo(Calendario pCalendario)
        {
            return (new CalendarCodeAscendingComparer()).Compare(this, pCalendario);
        }
    }
}
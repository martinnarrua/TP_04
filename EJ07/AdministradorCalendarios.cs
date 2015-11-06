using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ07.Criteria;
using EJ07.Exceptions;

namespace EJ07
{
    /// <summary>
    /// Representa un administrador de calendarios
    /// </summary>
    class AdministradorCalendarios : IRepositorioCalendarios
    {
        /// <summary>
        /// Diccionario que contiene todos los calendarios del administrador
        /// </summary>
        private SortedDictionary<string, Calendario> Calendarios { get; set; }

        /// <summary>
        /// Agrega un <see cref="Calendario"/> al Administardor
        /// </summary>
        /// <param name="pCalendario">Calendario a agregar</param>
        /// <exception cref="ArgumentNullException">Si el calendario, el titulo o el codigo es null</exception>
        /// <exception cref="ArgumentException">si el titulo o el codigo es el string vacio</exception>
        /// <exception cref="CalendarioExistenteException">si el calendario ya existe en el administrador</exception>
        void IRepositorioCalendarios.Agregar(Calendario pCalendario)
        {
            if (pCalendario == null)
            {
                throw (new ArgumentNullException("pCalendario", "No se pudo agregar el calendario, el mismo es invalido"));
            }
            else if (pCalendario.Titulo == null)
            {
                throw (new ArgumentNullException("pCalendario.Titulo", "No se pudo agregar el calendario, el titulo es invalido"));
            }
            else if (pCalendario.Codigo == null)
            {
                throw (new ArgumentNullException("pCalendario.Codigo", "No se pudo agregar el calendario, el codigo es invalido"));
            }
            else if (pCalendario.Titulo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Titulo", "No se pudo agregar el calendario, el titulo del mismo esta vacio"));
            }
            else if (pCalendario.Codigo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Codigo", "No se pudo agregar el calendario, el codigo del mismo esta vacio"));
            }
            else if (this.Calendarios.ContainsKey(pCalendario.Codigo))
            {
                CalendarioExistenteException lException = new CalendarioExistenteException(String.Format("No se pudo agregar el calendario, ya existe un calendario con el codigo '{0}'", pCalendario.Codigo));
                throw lException;
            }
            this.Calendarios.Add(pCalendario.Codigo, pCalendario.Copiar());
            
        }

        /// <summary>
        /// Actualiza la informacion de un <see cref="Calendario"/> 
        /// </summary>
        /// <param name="pCalendario">Calendario a actualizar</param>
        /// <exception cref="ArgumentNullException">Si el calendario, el titulo o el codigo es null</exception>
        /// <exception cref="ArgumentException">si el titulo o el codigo es el string vacio</exception>
        /// <exception cref="CalendarioNoEncontradoException">si el calendario no existe en el calendario</exception>
        void IRepositorioCalendarios.Actualizar(Calendario pCalendario)
        {
            if (pCalendario == null)
            {
                throw (new ArgumentNullException("pCalendario", "No se pudo actualizar el calendario, el mismo es invalido"));
            }
            else if (pCalendario.Titulo == null)
            {
                throw (new ArgumentNullException("pCalendario.Titulo", "No se pudo actualizar el calendario, el titulo es invalido"));
            }
            else if (pCalendario.Codigo == null)
            {
                throw (new ArgumentNullException("pCalendario.Codigo", "No se pudo actualizar el calendario, el codigo es invalido"));
            }
            else if (pCalendario.Titulo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Titulo", "No se pudo actualizar el calendario, el titulo del mismo esta vacio"));
            }
            else if (pCalendario.Codigo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Codigo", "No se pudo actualizar el calendario, el codigo del mismo esta vacio"));
            }
            else if (!this.Calendarios.ContainsKey(pCalendario.Codigo))
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCalendario.Codigo));
                throw lException;
            }
            this.Calendarios[pCalendario.Codigo] = pCalendario.Copiar();

        }

        /// <summary>
        /// Elimina un <see cref="Calendario"/> del Repositorio
        /// </summary>
        /// <param name="pCodigo">Codigo del calendario a Eliminar</param>
        /// <exception cref="ArgumentNullException">Si el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="CalendarioNoEncontradoException">si el calendario no existe en el administrador</exception>
        void IRepositorioCalendarios.Eliminar(string pCodigo)
        {
            if (pCodigo == null)
            {
                throw new ArgumentNullException("pCodigo", "El codigo ingresado es invalido");
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("pCodigo", "El codigo no puede ser vacio"));
            }
            else if (! (this.Calendarios.ContainsKey(pCodigo)))
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCodigo));
                throw lException;
            }
            this.Calendarios.Remove(pCodigo);
        }

        /// <summary>
        /// Obtiene todos las instancias de <see cref="Calendario"/> contenidas en el calendario
        /// </summary>
        /// <returns>Lista de todos los calendarios</returns>
        IList<Calendario> IRepositorioCalendarios.ObtenerTodos()
        {
            List<Calendario> lLista = (List<Calendario>)this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }

        /// <summary>
        /// Permite obtener la instancia de <see cref="Calendario"/> cuyo codigo es igual a <paramref name="pCodigo"/>
        /// </summary>
        /// <param name="pCodigo">Codigo del calendario que se desea obtener</param>
        /// <returns>el calendario en caso de encontrarse</returns>
        /// <exception cref="ArgumentNullException">Si el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="CalendarioNoEncontradoException">si el calendario no existe en el administrador/exception>
        Calendario IRepositorioCalendarios.ObtenerPorCodigo(string pCodigo)
        {
            if (pCodigo == null)
            {
                throw new ArgumentNullException("pCodigo", "El codigo ingresado es invalido");
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("pCodigo", "El codigo no puede estar vacio"));
            }
            else if (!(this.Calendarios.ContainsKey(pCodigo)))
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCodigo));
                throw lException;
            }
            return this.Calendarios[pCodigo];
        }

        /// <summary>
        /// Obtiene ordenadas las instancias de <see cref="Calendario"/> contenidas en el calendario
        /// </summary>
        /// <param name="pComparador">Implementador de <see cref="IComparer{Calendario}"/>, el cual define el criterio del ordenamiento</param>
        /// <returns>Lista de todos los calendarios ordenados</returns>
        IList<Calendario> IRepositorioCalendarios.ObtenerOrdenadosPor(IComparer<Calendario> pComparador)
        {
            List<Calendario> lLista = (List<Calendario>)this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCriterio"></param>
        /// <returns></returns>
        IList<Calendario> IRepositorioCalendarios.ObtenerPorCriterio(ICriteria<Calendario> pCriterio)
        {
            IList<Calendario> lLista = ObtenerSinOrdenar();
            return pCriterio.SatisfacenCriterio(lLista);
        }

        /// <summary>
        /// Permite obtener una lista de todos los <see cref="Calendario"/>, sin ordenar
        /// </summary>
        /// <returns>Lista de Calendarios</returns>
        private IList<Calendario> ObtenerSinOrdenar()
        {
            List<Calendario> lLista = this.Calendarios.Values.ToList();
            return lLista;
        }
    }
}

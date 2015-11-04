using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ07.Criteria;
using EJ07.Exceptions;

namespace EJ07
{
    class AdministradorCalendarios : IRepositorioCalendarios
    {
        private SortedDictionary<string, Calendario> Calendarios { get; set; }        

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
            else if (pCalendario.Titulo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Titulo", "No se pudo agregar el calendario, el titulo del mismo esta vacio"));
            }
            else if (this.Calendarios.ContainsKey(pCalendario.Titulo))
            {
                CalendarioExistenteException lException = new CalendarioExistenteException(String.Format("No se pudo agregar el calendario, ya existe un calendario con el titulo '{0}'", pCalendario.Titulo));
                throw lException;
            }

            this.Calendarios.Add(pCalendario.Titulo, pCalendario.Copiar());
            
        }

        void IRepositorioCalendarios.Actualizar(Calendario pCalendario, Calendario pCalendarioModificado)
        {
            /*
                El calendario tiene titulo, fecha creacion y fecha modificacion.
                Entonces, la fecha de creacion yo no la deberia poder modificar
                la fecha de modificacion se deberia actualizar cada vez que se modifique el titulo o uno de los eventos del mismo
                la fecha de creacion deberia ser read only
                    

            */
            if (pCalendario == null)
            {
                throw (new ArgumentNullException("pCalendario", "No se pudo actualiza el calendario, el mismo es invalido"));
            }
            else if (pCalendario.Titulo == null)
            {
                throw (new ArgumentNullException("pCalendario.Titulo", "No se pudo actualizar el calendario, el titulo es invalido"));
            }
            else if (pCalendario.Titulo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Titulo", "No se pudo actualizar el calendario, el titulo del mismo esta vacio"));
            }
            else if (! this.Calendarios.ContainsKey(pCalendario.Titulo))
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el nombre '{0}'", pCalendario.Titulo));
                throw lException;
            }
            this.Calendarios[pCalendario.Titulo].Modificar(pCalendarioModificado);

            //this.Calendarios[pCalendario.Titulo] = pCalendario.Copiar();
        }

        void IRepositorioCalendarios.Eliminar(string pTitulo)
        {
            bool eliminado = false;
            if (this.Calendarios.ContainsKey(pTitulo))
            {
                this.Calendarios.Remove(pTitulo);
                eliminado = true;
                }
            if (!eliminado)
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el nombre '{0}'", pCalendario.Titulo));
                throw lException;
            }
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerTodos()
        {
            return this.Calendarios.Values.ToList();
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

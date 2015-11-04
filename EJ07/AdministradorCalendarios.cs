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
            else if (this.Calendarios.ContainsKey(pCalendario.Codigo))
            {
                CalendarioExistenteException lException = new CalendarioExistenteException(String.Format("No se pudo agregar el calendario, ya existe un calendario con el codigo '{0}'", pCalendario.Codigo));
                throw lException;
            }
            this.Calendarios.Add(pCalendario.Codigo, pCalendario.Copiar());
            
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
            else if (! this.Calendarios.ContainsKey(pCalendario.Codigo))
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCalendario.Codigo));
                throw lException;
            }
            this.Calendarios[pCalendario.Codigo].Modificar(pCalendarioModificado);

            //this.Calendarios[pCalendario.Titulo] = pCalendario.Copiar();
        }

        void IRepositorioCalendarios.Eliminar(string pCodigo)
        {
            bool eliminado = false;
            if (this.Calendarios.ContainsKey(pCodigo))
            {
                this.Calendarios.Remove(pCodigo);
                eliminado = true;
                }
            if (!eliminado)
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCodigo));
                throw lException;
            }
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerTodos()
        {
            List<Calendario> lLista = (List<Calendario>)this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }

        Calendario IRepositorioCalendarios.ObtenerPorCodigo(string pCodigo)
        {
            if (this.Calendarios.ContainsKey(pCodigo))
            {
                return this.Calendarios[pCodigo];
            }
            else
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCodigo));
                throw lException;
            }
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerOrdenadosPor(IComparer<Calendario> pComparador)
        {
            List<Calendario> lLista = (List<Calendario>)this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerPorCriterio(ICriteria<Calendario> pCriterio)
        {
            throw new NotImplementedException();
        }

        private IList<Calendario> ObtenerSinOrdenar()
        {
            List<Calendario> lLista = this.Calendarios.Values.ToList();
            return lLista;
        }
    }
}

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
            else if (pCalendario.Titulo == String.Empty)
            {
                throw (new ArgumentException("pCalendario.Titulo", "No se pudo actualizar el calendario, el titulo del mismo esta vacio"));
            }
            else if (!this.Calendarios.ContainsKey(pCalendario.Codigo))
            {
                CalendarioNoEncontradoException lException = new CalendarioNoEncontradoException(String.Format("No se encontro el calendario con el codigo '{0}'", pCalendario.Codigo));
                throw lException;
            }
            this.Calendarios[pCalendario.Codigo] = pCalendario.Copiar();

        }

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

        IList<Calendario> IRepositorioCalendarios.ObtenerTodos()
        {
            List<Calendario> lLista = (List<Calendario>)this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }

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

        IList<Calendario> IRepositorioCalendarios.ObtenerOrdenadosPor(IComparer<Calendario> pComparador)
        {
            List<Calendario> lLista = (List<Calendario>)this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerPorCriterio(ICriteria<Calendario> pCriterio)
        {
            IList<Calendario> lLista = ObtenerSinOrdenar();
            return pCriterio.SatisfacenCriterio(lLista);
        }

        private IList<Calendario> ObtenerSinOrdenar()
        {
            List<Calendario> lLista = this.Calendarios.Values.ToList();
            return lLista;
        }
    }
}

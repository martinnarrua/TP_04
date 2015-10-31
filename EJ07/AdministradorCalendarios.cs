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

        public void ModificarCalendario(string pTitulo,string pNuevoTitulo)
        {
            bool modificado = false;
            foreach (Calendario cal in Calendarios)
            {
                if(cal.Titulo == pTitulo)
                {
                    cal.Modificar(pNuevoTitulo);
                    modificado = true;
                } 
            }
            if (!modificado)
            {
                Exception e = new Exception("No se encontro el calendario especificado");
                throw e;
            }
        }

        public void ListarCalendarios()
        {
            foreach (Calendario cal in Calendarios)
            {
                Console.WriteLine("Titulo del calendario: {0}",cal.Titulo);
                Console.WriteLine("Fecha y hora de creacion: {0}, {1}",cal.FechaCreacion,cal.HoraCreacion);
                Console.WriteLine("Fecha y hora de ultima modificacion: {0}, {1}", cal.FechaModificacion, cal.HoraModificacion);
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        public void EliminarCalendario(string pTitulo)
        {
            bool eliminado = false;
            foreach (Calendario cal in Calendarios)
            {
                if (cal.Titulo == pTitulo)
                {
                    Calendarios.Remove(cal);
                    eliminado = true;
                }
            }
            if (!eliminado)
            {
                Exception e = new Exception("No se encontro el calendario especificado");
                throw e;
            }
        }

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

        void IRepositorioCalendarios.Actualizar(Calendario pCalendario)
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

            this.Calendarios[pCalendario.Titulo] = pCalendario.Copiar();
        }

        void IRepositorioCalendarios.Eliminar(string pTitulo)
        {
            throw new NotImplementedException();
        }

        IList<Calendario> IRepositorioCalendarios.ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        Calendario IRepositorioCalendarios.ObtenerPorNombre(string pNombre)
        {
            throw new NotImplementedException();
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

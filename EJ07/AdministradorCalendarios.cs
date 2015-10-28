using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07
{
    class AdministradorCalendarios
    {
        private List<Calendario> Calendarios;

        public void AgregarCalendario(Calendario pCalendario)
        {
            Calendarios.Add(pCalendario);
        }
   
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class CapaVista
    {
        public void Ejecutar()
        {
            try
            {
                CapaControlador controlador = new CapaControlador();
                controlador.Ejecutar();
            }
            catch (CapaAplicacionException exception)
            {
                Console.WriteLine("Primera excepcion: {0}",exception.InnerException.Message);
                Console.WriteLine("Segunda excepcion: {0}",exception.Message);
                Console.WriteLine("CallStack {0}",exception.StackTrace);
            }   
        }
    }
}

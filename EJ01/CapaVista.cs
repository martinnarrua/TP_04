using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa la capa vista de un programa
    /// </summary>
    class CapaVista
    {
        /// <summary>
        /// Metodo que instancia un objeto de la capa n+1 y ejecuta la metodo "Ejecutar" de esta ultima. 
        /// En este caso particular es la capa con la que interactua el usuario, por lo tanto muestra la informacion de las excepciones 
        /// lanzadas durante la ejecucion
        /// </summary>
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
                Console.ReadKey();
                Console.WriteLine("Segunda excepcion: {0}",exception.Message);
                Console.ReadKey();
                Console.WriteLine("CallStack {0}",exception.StackTrace);
            }   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa la capa controlador de un programa
    /// </summary>
    class CapaControlador
    {
        /// <summary>
        /// Metodo que instancia un objeto de la capa n+1 y ejecuta la metodo "Ejecutar" de esta ultima
        /// </summary>
        public void Ejecutar()
        {
            CapaAplicacion aplicacion = new CapaAplicacion(); 
            aplicacion.Ejecutar();
        }
    }
}

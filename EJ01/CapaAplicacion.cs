using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa la capa aplicacion de un programa
    /// </summary>
    class CapaAplicacion
    {
        /// <summary>
        /// Metodo que instancia un objeto de la capa n+1 y ejecuta la metodo "Ejecutar" de esta ultima
        /// </summary>
        public void Ejecutar()
        {
            try
            {
                CapaDominio dominio = new CapaDominio();
                dominio.Ejecutar();
            }
            catch(ErrorPuntualException exception)
            {
                CapaAplicacionException exception2 = new CapaAplicacionException("Se produjo un error generico ", exception);
                throw exception2;
            }    
        }
    }
}

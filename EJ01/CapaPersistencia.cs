using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa la capa persistencia de un programa
    /// </summary>
    class CapaPersistencia
    {
        /// <summary>
        /// Metodo que instancia un objeto de la capa n+1 y ejecuta la metodo "Ejecutar" de esta ultima. 
        /// En este caso particular es la ultima capa y solo lanza la excepcion solicitada
        /// </summary>
        public void Ejecutar()
        {
            ErrorPuntualException exception = new ErrorPuntualException("Ocurrio un error en la capa Persistencia, fecha y hora: ");
            throw exception;
        }
    }
}

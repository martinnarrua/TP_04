using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa un error especifico de la aplicacion
    /// </summary>
    class ErrorPuntualException: ApplicationException
    {
        /// <summary>
        /// Constructor de la clase <see cref="ErrorPuntualException"/>
        /// </summary>
        /// <param name="mensaje">mensaje que describe la excepcion lanzada</param>
        public ErrorPuntualException(string mensaje): base(mensaje + DateTime.Now) { }

    }
}

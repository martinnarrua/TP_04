using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa un error generico de la aplicacion
    /// </summary>
    class CapaAplicacionException:ApplicationException
    {
        /// <summary>
        /// Constructor de la clase <see cref="CapaAplicacionException"/>
        /// </summary>
        /// <param name="mensaje">mensaje que describe la excepcion lanzada</param>
        /// <param name="exception">excepcion que generó el lanzamiento de esta excepcion</param>
        public CapaAplicacionException(string mensaje, ErrorPuntualException exception):base(mensaje,exception) { }
    }
}

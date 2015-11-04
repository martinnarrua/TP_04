using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa una excepcion lanzada cuando se intenta dividir un numero por 0
    /// </summary>
    public class DivisionPorCeroException:Exception
    {
        /// <summary>
        /// Constructor de la clase <see cref="DivisionPorCeroException"/>
        /// </summary>
        /// <param name="mensaje">mensaje que describe la excepcion lanzada</param>
        public DivisionPorCeroException(string mensaje):base(mensaje) { }
    }
}

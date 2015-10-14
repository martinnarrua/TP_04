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
        public CapaAplicacionException(string mensaje, ErrorPuntualException exception):base(mensaje,exception) { }
    }
}

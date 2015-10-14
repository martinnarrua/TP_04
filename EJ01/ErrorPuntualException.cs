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
        public ErrorPuntualException(string mensaje): base(mensaje + DateTime.Now) { }

    }
}

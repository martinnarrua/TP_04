using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ05.Exceptions
{
    /// <summary>
    /// Representa la excepcion que se arroja cuando existe un usuario y se desea volver a agregar el mismo al repositorio
    /// </summary>
    public class UsuarioExistenteException : ArgumentException
    {
        public UsuarioExistenteException() : base() { }

        public UsuarioExistenteException(string pMensaje) : base(pMensaje) { }
    }
}

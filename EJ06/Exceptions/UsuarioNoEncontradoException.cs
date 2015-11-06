using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06.Exceptions
{
    /// <summary>
    /// Representa la excepcion que se arroja cuando se desea realizar una operacion sobre un usuario que no existe dentro del repositorio
    /// </summary>
    public class UsuarioNoEncontradoException : KeyNotFoundException
    {
        public UsuarioNoEncontradoException() : base() { }

        public UsuarioNoEncontradoException(string pMensaje) : base(pMensaje) { }
    }
}
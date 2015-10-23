using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ05
{
    public class UsuarioNoEncontradoException : KeyNotFoundException
    {
        public UsuarioNoEncontradoException() : base() { }

        public UsuarioNoEncontradoException(string pMensaje) : base(pMensaje) { }
    }
}

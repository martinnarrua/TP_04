using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Exceptions
{
    public class CalendarioNoEncontradoException : System.Exception
    {
        public CalendarioNoEncontradoException() : base() { }

        public CalendarioNoEncontradoException(string pMensaje) : base(pMensaje) { }

        public CalendarioNoEncontradoException(string pMensaje, System.Exception pExcepcionInterna) : base(pMensaje, pExcepcionInterna) { }
    }
}

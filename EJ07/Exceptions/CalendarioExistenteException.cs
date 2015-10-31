using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Exceptions
{
    public class CalendarioExistenteException : System.Exception
    {
        public CalendarioExistenteException() : base() { }

        public CalendarioExistenteException(string pMensaje) : base(pMensaje) { }

        public CalendarioExistenteException(string pMensaje, System.Exception pExcepcionInterna) : base(pMensaje,pExcepcionInterna) { }

    }
}

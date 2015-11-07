using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Exceptions
{
    public class EventoExistenteException : System.Exception
    {
        public EventoExistenteException() : base() { }

        public EventoExistenteException(string pMensaje) : base(pMensaje) { }

        public EventoExistenteException(string pMensaje, System.Exception pExcepcionInterna) : base(pMensaje,pExcepcionInterna) { }
    }
}

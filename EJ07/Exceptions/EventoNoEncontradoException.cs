using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Exceptions
{
    public class EventoNoEncontradoException : System.Exception
    {
        public EventoNoEncontradoException() : base() { }

        public EventoNoEncontradoException(string pMensaje) : base(pMensaje) { }

        public EventoNoEncontradoException(string pMensaje, System.Exception pExcepcionInterna) : base(pMensaje,pExcepcionInterna) { }
    }
}

using System;

namespace EJ07.Exceptions
{

    public class TituloCalendarioInvalidoException : System.Exception
    {
        public TituloCalendarioInvalidoException() : base() { }

        public TituloCalendarioInvalidoException(string pMensaje) : base(pMensaje) { }

        public TituloCalendarioInvalidoException(string pMensaje, System.Exception pExcepcionInterna) : base(pMensaje, pExcepcionInterna) { }
    }
}
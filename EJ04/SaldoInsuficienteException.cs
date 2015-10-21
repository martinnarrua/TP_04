using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class SaldoInsuficienteException : Exception
    {
        public SaldoInsuficienteException() : base() { }
        public SaldoInsuficienteException(string pMensaje): base(pMensaje) { }
    }
}

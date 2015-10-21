using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class DesbordamientoException: OverflowException
    {
        public DesbordamientoException():base() { }


        public DesbordamientoException(string pMensaje) : base(pMensaje) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class DivisionPorCeroException:Exception
    {
        public DivisionPorCeroException(string mensaje):base(mensaje) { }
    }
}

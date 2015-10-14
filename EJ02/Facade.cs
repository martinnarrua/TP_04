using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class Facade
    {
        public double Division(int pDividendo, int pDivisor)
        {
            return (Matematica.Dividir(pDividendo, pDivisor));
        }
    }
}

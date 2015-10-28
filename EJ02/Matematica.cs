using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    public class Matematica
    {
        public static double Dividir(int dividendo, int divisor)
        {
            if (dividendo == 0)
            {
                DivisionPorCeroException exception = new DivisionPorCeroException("Usted intento dividir un 0");
                throw exception;
            }
            if (divisor == 0)
            {
                DivisionPorCeroException exception = new DivisionPorCeroException("Usted intento dividir por 0");
                throw exception;
            }
            return (dividendo / divisor);

        }
    }
}

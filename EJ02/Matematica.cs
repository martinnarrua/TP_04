using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa una clase de operaciones matematicas
    /// </summary>
    public class Matematica
    {
        /// <summary>
        /// Divide dos numeros enteros especificados como parametros
        /// </summary>
        /// <param name="pDividendo">dividendo de la division</param>
        /// <param name="pDivisor">divisor de la division</param>
        /// <returns>Resultado de la division</returns>
        public static double Dividir(int? pDividendo, int? pDivisor)
        {
            if (pDivisor == 0)
            {
                DivisionPorCeroException exception = new DivisionPorCeroException("Usted intento dividir por 0");
                throw exception;
            }
            if (pDividendo == null)
            {
                ArgumentNullException exception = new ArgumentNullException("Dividendo invalido");
            }
            if (pDivisor == null)
            {
                ArgumentNullException exception = new ArgumentNullException("Divisor invalido");
            }
            return (double)(pDividendo / pDivisor);
        }
    }
}

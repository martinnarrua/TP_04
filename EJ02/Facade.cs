using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Abstrae la interaccion del usuario con la aplicacion
    /// </summary>
    class Facade
    {
        /// <summary>
        /// Permite dividir dos numeros enteros
        /// </summary>
        /// <param name="pDividendo">dividendo de la division</param>
        /// <param name="pDivisor">divisor de la division</param>
        /// <returns>Resultado de la division</returns>
        public double Division(int pDividendo, int pDivisor)
        {
            return (Matematica.Dividir(pDividendo, pDivisor));
        }
    }
}

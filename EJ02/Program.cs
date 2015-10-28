using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade cFachada = new Facade();
            try
            {
                Console.Write("Ingrese el diviendo de la operacion ");
                int dividendo = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el divisor de la operacion ");
                int divisor = int.Parse(Console.ReadLine());
                Console.WriteLine("El resultado de la division es: {0}",cFachada.Division(dividendo, divisor));
            }
            catch (DivisionPorCeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}

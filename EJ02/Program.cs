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
                int dividendo = int.Parse(Console.ReadLine());

                int divisor = int.Parse(Console.ReadLine());

                Console.WriteLine(cFachada.Division(dividendo, divisor));
            }
            catch (DivisionPorCeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}

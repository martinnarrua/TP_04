using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    class Program
    {
        static void Main(string[] argumento )
        {
            Console.WriteLine("Presione una tecla para comenzar la ejecucion");
            Console.ReadKey();
            CapaVista vista = new CapaVista();
            vista.Ejecutar();
            Console.ReadKey();
        }
    }
}

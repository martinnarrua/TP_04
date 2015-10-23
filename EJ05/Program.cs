
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace EJ05
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-AR");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("es-AR");

            Console.WriteLine(String.Compare("A", "Z", true, Thread.CurrentThread.CurrentCulture) > 1 ? "A sigue a Z en el ordenamiento" : "A precede a Z en el ordenamiento");
            Console.WriteLine(String.Compare("A", "Z", true, Thread.CurrentThread.CurrentCulture) > 1 ? "A sigue a Z en el ordenamiento" : "A precede a Z en el ordenamiento");
            Console.ReadKey();
        }
    }
}

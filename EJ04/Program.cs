using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Clase Solucion del Ejercicio 02 del Trabajo Practico 02
    /// </summary>
    class Program
    {

        /// <summary>
        /// Miembro estatico <see cref="Facade"/>, utilizado para abstraer implementaciones de las clases particulares al ejercicio
        /// </summary>
        static Facade cFachada;
        /// <summary>
        /// Muestra la Pantalla de Despedida del programa
        /// </summary>
        static void GoodBye()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                    Thank you for trusting MARR Systems Inc.  ");
            Console.ReadKey();
        }
        /// <summary>
        /// Muestra una cadena de caracteres, utilizado como separador en los menues principales por consola
        /// </summary>
        static void SeparadorMenuPrincipal()
        {
            Console.WriteLine("\n************************** Menu Principal *************************\n");
        }
        /// <summary>
        /// Muestra una cadena de caracteres, utilizado como separador en los menues secundarios por consola
        /// </summary>
        static void SeparadorOperatoria()
        {
            Console.WriteLine("\n-------------------Operando------------------\n");
        }

        static void Operatoria(String pCodigoCuenta)
        {
            bool seguir = true;
            double aux = 0;
            while (seguir)
            {
                SeparadorOperatoria();
                Console.WriteLine("¿Que operacion desea realizar?");
                Console.WriteLine("1:\t Mostrar Saldo");
                Console.WriteLine("2:\t Acreditar Saldo");
                Console.WriteLine("3:\t Debitar Saldo");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Cuenta lCuenta = cFachada.GetCuenta(pCodigoCuenta);
                        Console.Write("El saldo de la cuenta es de {0} {1}", lCuenta.Moneda.Simbolo, lCuenta.Saldo);
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Ingrese el saldo a Acreditar: ");
                        aux = double.Parse(Console.ReadLine());
                        Console.Write(cFachada.AcreditarSaldo(pCodigoCuenta, aux) ? "La operacion se realizo correctamente" : "La operacion no pudo realizarse");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Write("Ingrese el saldo a Debitar: ");
                        aux = double.Parse(Console.ReadLine());
                        Console.Write(cFachada.DebitarSaldo(pCodigoCuenta, aux) ? "La operacion se realizo correctamente" : "La operacion no pudo realizarse");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 0:
                        seguir = false;
                        break;
                    default:
                        Console.Write("Opcion incorrecta. Reintente");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            cFachada = new Facade();
            bool seguir = true;
            while (seguir)
            {
                SeparadorMenuPrincipal();
                Console.WriteLine("¿Con que cuenta desea operar?");
                Console.WriteLine("1:\t Dolares (USD)");
                Console.WriteLine("2:\t Pesos Argentinos (ARS)");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Operatoria("USD");
                        break;
                    case 2:
                        Operatoria("ARS");
                        break;
                    case 0:
                        seguir = false;
                        break;
                    default:
                        Console.Write("Opcion incorrecta. Reintente");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
            GoodBye();
        }
    }
}

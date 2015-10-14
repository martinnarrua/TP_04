using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EJ03
{
    class Program
    {
        static void ImprimirLineas()
        {

        }

        static void ImprimirArchivoUsing (string pRutaArchivo)
        {
            try
            {
                using ( FileInfo archivo = FileInfo(pRutaArchivo))
                {
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void Main(string[] args)
        {
            //holisssss
            // jiknm

   
        }
    }
}

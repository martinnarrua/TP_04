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
        static void ImprimirLineas(StreamReader pStreamTexto)
        {

        }

        static void ImprimirArchivoExcepciones(string[] pArgumentos)
        {
            try
            {

            }
            catch (FileNotFoundException nfE)
            {
                
                throw;
            }
            catch (FileNotFoundException nfE)
            {

                throw;
            }
            finally
        {

        }
        }

        static void ImprimirArchivoUsing (string pRutaArchivo)
        {
            try
            {
                using (FileInfo archivo = new FileInfo(pRutaArchivo));
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
            try
            {
                String lRuta = args[0];
                ImprimirArchivoExcepciones(args);
            }
            catch (ArgumentException aE)
            {

                throw;
            }

            //hola me llamo pacucito
        }
    }
}

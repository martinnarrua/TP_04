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
                pRutaArchivo = Path.GetFullPath(pRutaArchivo);
                FileInfo archivo = new FileInfo(pRutaArchivo);
                using (StreamReader texto = archivo.OpenText())
                {
                    ImprimirLineas(texto);
                }
            }
            catch (ArgumentNullException sinArgumento)
            {
                sinArgumento = new ArgumentNullException("No se ingreso una ruta");
                throw sinArgumento;
            }
            catch(FileNotFoundException noExisteArchivo)
            {
                noExisteArchivo = new FileNotFoundException("El archivo especificado no existe");
                throw noExisteArchivo;
            }
            catch()
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

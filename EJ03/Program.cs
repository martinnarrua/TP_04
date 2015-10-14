﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EJ03
{
    class Program
    {
        static void ImprimirLineas(StreamReader pStreamTexto, String pRutaArchivo)
        {
            Console.WriteLine("Contenidos del Archivo '{0}': \n", pRutaArchivo);
            int i = 1;
            while (!pStreamTexto.EndOfStream)
            {
                Console.WriteLine("Linea {0}:\t {1}\n",i.ToString("D4"),pStreamTexto.ReadLine());
            }
            Console.WriteLine("\t\t\t Fin de archivo...\n");
        }

        static void ImprimirArchivoExcepciones(string pRutaArchivo)
        {
            StreamReader lSreader = null;
            try
            {
                pRutaArchivo = Path.GetFullPath(pRutaArchivo);
                lSreader = new StreamReader(pRutaArchivo);
                ImprimirLineas(lSreader, pRutaArchivo);
            }
            catch (ArgumentException aE)
            {
                ArgumentException lException = new ArgumentException(String.Format("La ruta proporcionada: '{0}' no es valida", pRutaArchivo), pRutaArchivo);
                throw lException;
            }
            catch (FileNotFoundException fnfE)
            {
                FileNotFoundException lException = new FileNotFoundException(String.Format("No existe el archivo '{0}'",pRutaArchivo), pRutaArchivo);
                throw lException;
            }
            catch (Exception e)
            {
                Exception lException = new Exception(String.Format("La aplicacion arrojo una excepcion no manejada: '{0}'", e.Message),e);
                throw lException;
            }
            finally
            {
                if (lSreader != null)
                {
                    lSreader.Dispose();
                }
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
                    ImprimirLineas(texto,pRutaArchivo);
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
            catch(Exception e)
            {

            }
        }


        static void Main(string[] args)
        {
            try
            {
                String lRuta = args[0];
                ImprimirArchivoExcepciones(lRuta);
            }
            catch (ArgumentOutOfRangeException aoorE)
            {
                Console.WriteLine("No se proporciono ningun Archivo");
            }
            catch (ArgumentException aE)
            {
                Console.WriteLine(aE.Message);
            }
            catch (FileNotFoundException fnfE)
            {
                Console.WriteLine(fnfE.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

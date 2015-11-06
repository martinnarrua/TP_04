﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
    class Program
    {
        static void Main(string[] args)
        {
            /* CalculadorDistanciaLevenshtein calculador = new CalculadorDistanciaLevenshtein("ti", "Martin Arrúa");
             CalculadorDistanciaLevenshtein calculador1 = new CalculadorDistanciaLevenshtein("ti", "Agustina Mannise");
             CalculadorDistanciaLevenshtein calculador2 = new CalculadorDistanciaLevenshtein("ti", "Ramiro Rivera");
             Console.WriteLine(calculador.Calcular().ToString());
             Console.WriteLine(calculador1.Calcular().ToString());
             Console.WriteLine(calculador2.Calcular().ToString());
             Console.ReadKey();*/

            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            List<Usuario> lista = lRepositorio.BusquedaPorAproximacion("ti");
        }
    }
}

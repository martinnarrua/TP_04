using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;
using System.Collections.Generic;

namespace EJ06.Test
{
    [TestClass]
    public class RepositorioUsuariosTest
    {
        [TestMethod]
        public void BusquedaPorAproximacionTest()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            List<Usuario> lista = lRepositorio.BusquedaPorAproximacion("ti");

            Assert.AreEqual(2, lista.Count);
        }
    }
}

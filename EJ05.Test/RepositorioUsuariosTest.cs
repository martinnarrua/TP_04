﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;
using System.Collections.Generic;

namespace EJ05.Test
{
    [TestClass]
    public class RepositorioUsuariosTest
    {
        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodAsc()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa" , CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            RepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            List<Usuario> lLista = new List<Usuario> { lUsuario1, lUsuario2, lUsuario3 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>) lRepositorio.ObtenerOrdenadosPor(new UserCodeAscendingComparer());
            Assert.AreEqual(lLista.Count, lListaResultado.Count);

            for (int i = 0; i < lListaResultado.Count; i++)
            {
                Assert.AreEqual(lLista[i], lListaResultado[i]);
            }

        }
    }
}

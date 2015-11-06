using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;
using System.Collections.Generic;

namespace EJ05.Test
{
    [TestClass]
    public class RepositorioUsuariosTest
    {
        [TestMethod]
        public void ObtenerOrdenadosPor_WithDefaultSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            List<Usuario> lLista = new List<Usuario> { lUsuario1, lUsuario2, lUsuario3 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>) lRepositorio.ObtenerTodos();
            Assert.AreEqual(lLista.Count, lListaResultado.Count);

            for (int i = 0; i < lListaResultado.Count; i++)
            {
                Assert.AreEqual(lLista[i], lListaResultado[i]);
            }
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodAscSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa" , CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserCodeAscendingComparer();
            List<Usuario> lLista = new List<Usuario> { lUsuario1, lUsuario2, lUsuario3 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>) lRepositorio.ObtenerOrdenadosPor(lComparador);
            Assert.AreEqual(lLista.Count, lListaResultado.Count);

            for (int i = 0; i < lListaResultado.Count; i++)
            {
                Assert.AreEqual(lLista[i], lListaResultado[i]);
            }
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodDescSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserCodeDescendingComparer();

            List<Usuario> lLista = new List<Usuario> { lUsuario3, lUsuario2, lUsuario1 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>)lRepositorio.ObtenerOrdenadosPor(lComparador);
            Assert.AreEqual(lLista.Count, lListaResultado.Count);

            for (int i = 0; i < lListaResultado.Count; i++)
            {
                Assert.AreEqual(lLista[i], lListaResultado[i]);
            }
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithEmailAscSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserEmailAscendingComparer();
            List<Usuario> lLista = new List<Usuario> { lUsuario3, lUsuario1, lUsuario2 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>)lRepositorio.ObtenerOrdenadosPor(lComparador);
            Assert.AreEqual(lLista.Count, lListaResultado.Count);

            for (int i = 0; i < lListaResultado.Count; i++)
            {
                Assert.AreEqual(lLista[i], lListaResultado[i]);
            }
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithEmailDescSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserEmailDescendingComparer();

            List<Usuario> lLista = new List<Usuario> { lUsuario2, lUsuario1, lUsuario3 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>)lRepositorio.ObtenerOrdenadosPor(lComparador);
            Assert.AreEqual(lLista.Count, lListaResultado.Count);

            for (int i = 0; i < lListaResultado.Count; i++)
            {
                Assert.AreEqual(lLista[i], lListaResultado[i]);
            }
        }


    }
}

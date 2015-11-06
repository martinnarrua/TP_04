using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;
using System.Collections.Generic;
using System.Linq;
using EJ05.Exceptions;

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
           
            CollectionAssert.AreEqual(lLista, lListaResultado);
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

            CollectionAssert.AreEqual(lLista, lListaResultado);
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

            CollectionAssert.AreEqual(lLista, lListaResultado);
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

            CollectionAssert.AreEqual(lLista, lListaResultado);
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

            CollectionAssert.AreEqual(lLista, lListaResultado);
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithFullNameAscSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserFullNameAscendingComparer();
            List<Usuario> lLista = new List<Usuario> { lUsuario3, lUsuario1, lUsuario2 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>)lRepositorio.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lLista, lListaResultado);
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithFullNameDescSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserFullNameDescendingComparer();

            List<Usuario> lLista = new List<Usuario> { lUsuario2, lUsuario1, lUsuario3 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>)lRepositorio.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lLista, lListaResultado);
        }

        [TestMethod]
        public void Agregar_WithUsuarioNulo_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = null;
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario3);
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Agregar(lUsuario2);
                Assert.Fail();

            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Agregar_WithCodigoNulo_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = null, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario3);
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Agregar(lUsuario2);
                Assert.Fail();

            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Agregar_WithCodigoVacio_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = String.Empty, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario3);
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Agregar(lUsuario2);
                Assert.Fail();

            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void Agregar_WithUsuarioExistente_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario3);
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Agregar(lUsuario2);
                lRepositorio.Agregar(lUsuario1);
                Assert.Fail();

            }
            catch (UsuarioExistenteException) { }
        }





    }
}

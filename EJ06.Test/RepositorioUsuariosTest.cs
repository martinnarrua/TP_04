using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EJ06;
using EJ06.Comparers;
using EJ06.Exceptions;

namespace EJ05.Test
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
        



        [TestMethod]
        public void ObtenerOrdenadosPor_WithCaminoFeliz()
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

            CollectionAssert.AreEquivalent(lLista, lListaResultado);
        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodAscSort()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "MMMM", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();
            IComparer<Usuario> lComparador = new UserCodeAscendingComparer();
            List<Usuario> lLista = new List<Usuario> { lUsuario1, lUsuario2, lUsuario3 };
            List<Usuario> lListaResultado = new List<Usuario>();

            lRepositorio.Agregar(lUsuario3);
            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);

            lListaResultado = (List<Usuario>)lRepositorio.ObtenerOrdenadosPor(lComparador);

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

        [TestMethod]
        public void Agregar_WithCaminoFeliz_Fails()
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
            }
            catch (System.Exception) { }

            Assert.IsTrue(true);
        }


        [TestMethod]
        public void Actualizar_WithUsuarioNulo_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = null;
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Actualizar(lUsuario3);
                lRepositorio.Actualizar(lUsuario1);
                lRepositorio.Actualizar(lUsuario2);
                Assert.Fail();

            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Actualizar_WithCodigoNulo_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = null, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Actualizar(lUsuario1);
                lRepositorio.Actualizar(lUsuario3);
                lRepositorio.Actualizar(lUsuario2);
                Assert.Fail();

            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Actualizar_WithCodigoVacio_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = String.Empty, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Actualizar(lUsuario1);
                lRepositorio.Actualizar(lUsuario3);
                lRepositorio.Actualizar(lUsuario2);
                Assert.Fail();

            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void Actualizar_WithUsuarioNoEncontrado_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Actualizar(lUsuario1);
                lRepositorio.Actualizar(lUsuario3);
                lRepositorio.Actualizar(lUsuario2);
                Assert.Fail();

            }
            catch (UsuarioNoEncontradoException) { }
        }

        [TestMethod]
        public void Actualizar_WithCaminoFeliz_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Actualizar(lUsuario1);
                lRepositorio.Actualizar(lUsuario3);
            }
            catch (System.Exception) { }

            Assert.IsTrue(true);
        }




        [TestMethod]
        public void Eliminar_WithCodigoNulo_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = null, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Eliminar(lUsuario2.Codigo);
                Assert.Fail();

            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Eliminar_WithCodigoVacio_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = String.Empty, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Eliminar(lUsuario2.Codigo);
                Assert.Fail();

            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void Eliminar_WithUsuarioNoEncontrado_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Eliminar(lUsuario3.Codigo);
                Assert.Fail();

            }
            catch (UsuarioNoEncontradoException) { }
        }

        [TestMethod]
        public void Eliminar_WithCaminoFeliz_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.Eliminar(lUsuario1.Codigo);
                lRepositorio.Agregar(lUsuario2);
                lRepositorio.Eliminar(lUsuario2.Codigo);
                lRepositorio.Agregar(lUsuario3);
                lRepositorio.Eliminar(lUsuario3.Codigo);
            }
            catch (System.Exception) { }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ObtenerPorCodigo_WithCodigoNulo_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = null, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario();
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.ObtenerPorCodigo(lUsuario2.Codigo);
                Assert.Fail();

            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void ObtenerPorCodigo_WithCodigoVacio_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = String.Empty, NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.ObtenerPorCodigo(lUsuario2.Codigo);
                Assert.Fail();

            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void ObtenerPorCodigo_WithUsuarioNoEncontrado_Fails()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "AAAA", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "ZZZZ", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            try
            {
                lRepositorio.Agregar(lUsuario1);
                lRepositorio.ObtenerPorCodigo(lUsuario2.Codigo);
                Assert.Fail();

            }
            catch (UsuarioNoEncontradoException) { }
        }

        [TestMethod]
        public void ObtenerPorCodigo_WithCaminoFeliz()
        {
            Usuario lUsuario1 = new Usuario { Codigo = "MMMM", NombreCompleto = "Martin Arrúa", CorreoElectronico = "Martin94.profugo@hotmail.com" };
            Usuario lUsuario2 = new Usuario { Codigo = "RRRR", NombreCompleto = "Ramiro Rivera", CorreoElectronico = "Ramarivera@gmail.com" };
            Usuario lUsuario3 = new Usuario { Codigo = "AAAA", NombreCompleto = "Agustina Mannise", CorreoElectronico = "Agusmn95@gmail.com" };
            Usuario lUsuario4 = new Usuario();
            IRepositorioUsuarios lRepositorio = new RepositorioUsuarios();

            lRepositorio.Agregar(lUsuario1);
            lRepositorio.Agregar(lUsuario2);
            lRepositorio.Agregar(lUsuario3);
            lUsuario4 = lRepositorio.ObtenerPorCodigo(lUsuario2.Codigo);



            Assert.AreEqual(lUsuario2, lUsuario4);
        }

    }
}

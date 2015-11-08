using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ07;
using System.Collections.Generic;
using EJ07.Exceptions;
using EJ07.Comparers;
using EJ07.Criteria;
using EJ07.Criteria.Criterion;
using System.Linq;
using EJ07.Helpers;

namespace EJ07.Test
{
    [TestClass]
    public class AdministradorCalendariosTest
    {
        #region Agregar Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Agregar_WithCalendarioNulo_Fails()
        {
            Calendario lCalendario = null;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Agregar_WithTituloCalendarioNulo_Fails()
        {
            Calendario lCalendario = new Calendario(null, "UT");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Agregar_WithCodigoCalendarioNulo_Fails()
        {
            Calendario lCalendario = new Calendario("Unit Testing!", null);
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Agregar_WithTituloCalendarioVacio_Fails()
        {
            Calendario lCalendario = new Calendario(String.Empty, "UT");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Agregar_WithCodigoCalendarioVacio_Fails()
        {
            Calendario lCalendario = new Calendario("Unit Testing!", String.Empty);
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario);

        }

        [TestMethod]
        [ExpectedException(typeof(CalendarioExistenteException))]
        public void Agregar_WithCalendarioExistente_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "UT");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);
        }

        [TestMethod]
        public void Agregar_WithCaminoFeliz()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                          "TPM",
                                          new DateTime(2015, 08, 05, 17, 30, 00),
                                          new DateTime(2015, 08, 05, 20, 30, 00),
                                          FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario1, lCalendario2 };
            List<Calendario> lResultado = new List<Calendario>();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado = (List<Calendario>)lAdministrador.ObtenerTodos();

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);
        }

        #endregion
        #region Actualizar Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Actualizar_WithCalendarioNulo_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = null;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Actualizar_WithCodigoCalendarioNulo_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", null); ;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Actualizar_WithTituloCalendarioNulo_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario(null, "TDP"); ;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Actualizar_WithCodigoCalendarioVacio_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", String.Empty);
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Actualizar_WithTituloCalendarioVacio_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario(String.Empty, "TDP"); ;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

        }

        [TestMethod]
        [ExpectedException(typeof(CalendarioNoEncontradoException))]
        public void Actualizar_WithCalendarioNoExistente_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

        }


        [TestMethod]
        public void Actualizar_WithCaminoFeliz()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                                      "TPM",
                                                      new DateTime(2015, 08, 05, 17, 30, 00),
                                                      new DateTime(2015, 08, 05, 20, 30, 00),
                                                      FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lCalendario1.Titulo = "Titulo 1 modificado";
            lCalendario2.Agregar(new Evento("Taller de Programacion",
                                    "TPV",
                                    new DateTime(2015, 08, 07, 17, 30, 00),
                                    new DateTime(2015, 08, 07, 20, 30, 00),
                                    FrecuenciaRepeticion.Semanal));

            lAdministrador.Actualizar(lCalendario1);
            lAdministrador.Actualizar(lCalendario2);

            Assert.IsTrue(true);
        }
        #endregion
        #region Eliminar Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Eliminar_WithCodigoCalendarioNulo_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", null); ;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Eliminar(lCalendario2.Codigo);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Eliminar_WithCodigoCalendarioVacio_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", String.Empty);
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Eliminar(lCalendario2.Codigo);

        }

        [TestMethod]
        [ExpectedException(typeof(CalendarioNoEncontradoException))]
        public void Eliminar_WithCalendarioNoExistente_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Eliminar(lCalendario2.Codigo);

        }


        [TestMethod]
        public void Eliminar_WithCaminoFeliz()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario>();
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                           "TPM",
                                           new DateTime(2015, 08, 05, 17, 30, 00),
                                           new DateTime(2015, 08, 05, 20, 30, 00),
                                           FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lAdministrador.Eliminar(lCalendario1.Codigo);
            lAdministrador.Eliminar(lCalendario2.Codigo);

            lResultado = (List<Calendario>)lAdministrador.ObtenerTodos();

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        #endregion
        #region ObtenerPorCodigo Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenerPorCodigo_WithCodigoCalendarioNulo_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", null); ;
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ObtenerPorCodigo_WithCodigoCalendarioVacio_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", String.Empty);
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo);

        }

        [TestMethod]
        [ExpectedException(typeof(CalendarioNoEncontradoException))]
        public void ObtenerPorCodigo_WithCalendarioNoExistente_Fails()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo);

        }


        [TestMethod]
        public void ObtenerPorCodigo_WithCaminoFeliz()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario1, lCalendario2 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerTodos();

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        #endregion
        #region ObtenerOrdenadosPor Test
        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodAscSort()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario2, lCalendario1 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            IComparer<Calendario> lComparador = new CalendarCodeAscendingComparer();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodDescSort()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario1, lCalendario2 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            IComparer<Calendario> lComparador = new CalendarCodeDescendingComparer();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithTitleAscSort()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario2, lCalendario1 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            IComparer<Calendario> lComparador = new CalendarTitleAscendingComparer();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithTitleDescSort()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario1, lCalendario2 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            IComparer<Calendario> lComparador = new CalendarTitleDescendingComparer();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCreationDateAscSort()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            System.Threading.Thread.Sleep(1);
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario1, lCalendario2 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            IComparer<Calendario> lComparador = new CalendarDateAscendingComparer();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCreationDateDescSort()
        {
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            System.Threading.Thread.Sleep(1);
            Calendario lCalendario2 = new Calendario("Taller de Programacion", "TDP");
            IRepositorioCalendarios lAdministrador = new AdministradorCalendarios();
            List<Calendario> lResultadoEsperado = new List<Calendario> { lCalendario2, lCalendario1 };
            List<Calendario> lResultado = new List<Calendario>();
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento3 = new Evento("Cumpleaños Martin Arrua",
                                            "CMA",
                                            new DateTime(2015, 06, 08, 00, 00, 00),
                                            new DateTime(2015, 06, 08, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            Evento lEvento4 = new Evento("Cumpleaños Agustina Mannise",
                                            "CAM",
                                            new DateTime(2015, 06, 14, 00, 00, 00),
                                            new DateTime(2015, 06, 14, 23, 59, 59),
                                            FrecuenciaRepeticion.Anual);
            IComparer<Calendario> lComparador = new CalendarDateDescendingComparer();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario2.Agregar(lEvento3);
            lCalendario2.Agregar(lEvento4);

            lAdministrador.Agregar(lCalendario1);
            lAdministrador.Agregar(lCalendario2);

            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario1.Codigo));
            lResultado.Add(lAdministrador.ObtenerPorCodigo(lCalendario2.Codigo));

            lResultado = (List<Calendario>)lAdministrador.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        #endregion
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ07;
using System.Collections.Generic;
using EJ07.Exceptions;
using EJ07.Comparers;
using EJ07.Criteria;
using EJ07.Criteria.Criterion;

namespace EJ07.Test
{
    [TestClass]
    public class CalendarioTest
    {
        #region Agregar Test
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))] 
        public void Agregar_WithEventoNulo_Fails()
        {
            Evento lEvento1 = null;
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Agregar_WithTituloEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento(null,
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Agregar_WithCodigoEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            null,
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Agregar_WithTituloEventoVacio_Fails()
        {
            Evento lEvento1 = new Evento(String.Empty,
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Agregar_WithCodigoEventoVacio_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            String.Empty,
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);

        }

        [TestMethod]
        [ExpectedException(typeof(EventoExistenteException))]
        public void Agregar_WithEventoExistente_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);

        }


        [TestMethod]
        public void Agregar_WithCaminoFeliz()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2, lEvento3, lEvento4 };
            List<Evento> lResultado = new List<Evento>();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>) lCalendario.ObtenerTodos();

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultadoEsperado);

        }
        #endregion
        #region Actualizar Test
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Actualizar_WithEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = null;
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Actualizar(lEvento2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Actualizar_WithCodigoEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            null,
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Actualizar(lEvento2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Actualizar_WithTituloEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento(null,
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Actualizar(lEvento2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Actualizar_WithCodigoEventoVacio_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            String.Empty,
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Actualizar(lEvento2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Actualizar_WithTituloEventoVacio_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento(String.Empty,
                                            "TPV",
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Actualizar(lEvento2);

        }


        [TestMethod]
        [ExpectedException(typeof(EventoNoEncontradoException))]
        public void Actualizar_WithEventoNoExistente_Fails()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Actualizar(lEvento2);

        }

        [TestMethod]
        public void Actualizar_WithCaminoFeliz()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2, lEvento3, lEvento4 };
            List<Evento> lResultado = new List<Evento>();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lEvento1.FechaComienzo = DateTime.Now;
            lEvento2.FechaFin = DateTime.Now;
            lEvento3.Titulo = "Cumpleaños de Martín Arrúa";
            lEvento4.Frecuencia = FrecuenciaRepeticion.Mensual;

            lCalendario.Actualizar(lEvento1);
            lCalendario.Actualizar(lEvento2);
            lCalendario.Actualizar(lEvento3);
            lCalendario.Actualizar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerTodos();

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }
        #endregion
        #region Eliminar Test
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Eliminar_WithCodigoEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            null,
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Eliminar(lEvento2.Codigo);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Eliminar_WithCodigoEventoVacio_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            String.Empty,
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Eliminar(lEvento2.Codigo);

        }


        [TestMethod]
        [ExpectedException(typeof(EventoNoEncontradoException))]
        public void Eliminar_WithEventoNoExistente_Fails()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.Eliminar(lEvento2.Codigo);

        }

        [TestMethod]
        public void Eliminar_WithCaminoFeliz()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { };
            List<Evento> lResultado = new List<Evento>();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lEvento1.FechaComienzo = DateTime.Now;
            lEvento2.FechaFin = DateTime.Now;
            lEvento3.Titulo = "Cumpleaños de Martín Arrúa";
            lEvento4.Frecuencia = FrecuenciaRepeticion.Mensual;

            lCalendario.Eliminar(lEvento1.Codigo);
            lCalendario.Eliminar(lEvento2.Codigo);
            lCalendario.Eliminar(lEvento3.Codigo);
            lCalendario.Eliminar(lEvento4.Codigo);

            lResultado = (List<Evento>)lCalendario.ObtenerTodos();

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }
        #endregion
        #region ObtenerPorCodigo Test
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ObtenerPorCodigo_WithCodigoEventoNulo_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            null,
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.ObtenerPorCodigo(lEvento2.Codigo);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ObtenerPorCodigo_WithCodigoEventoVacio_Fails()
        {
            Evento lEvento1 = new Evento("Taller de Programacion",
                                            "TPM",
                                            new DateTime(2015, 08, 05, 17, 30, 00),
                                            new DateTime(2015, 08, 05, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Evento lEvento2 = new Evento("Taller de Programacion",
                                            String.Empty,
                                            new DateTime(2015, 08, 07, 17, 30, 00),
                                            new DateTime(2015, 08, 07, 20, 30, 00),
                                            FrecuenciaRepeticion.Semanal);
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.ObtenerPorCodigo(lEvento2.Codigo);

        }


        [TestMethod]
        [ExpectedException(typeof(EventoNoEncontradoException))]
        public void ObtenerPorCodigo_WithEventoNoExistente_Fails()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");

            lCalendario.Agregar(lEvento1);
            lCalendario.ObtenerPorCodigo(lEvento2.Codigo);

        }

        [TestMethod]
        public void ObtenerPorCodigo_WithCaminoFeliz()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2, lEvento3, lEvento4 };
            List<Evento> lResultado = new List<Evento>();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);


            lEvento1.FechaComienzo = DateTime.Now;
            lEvento2.FechaFin = DateTime.Now;
            lEvento3.Titulo = "Cumpleaños de Martín Arrúa";
            lEvento4.Frecuencia = FrecuenciaRepeticion.Mensual;

            
            lResultado.Add(lCalendario.ObtenerPorCodigo(lEvento1.Codigo));
            lResultado.Add(lCalendario.ObtenerPorCodigo(lEvento2.Codigo));
            lResultado.Add(lCalendario.ObtenerPorCodigo(lEvento3.Codigo));
            lResultado.Add(lCalendario.ObtenerPorCodigo(lEvento4.Codigo));

            lResultado = (List<Evento>)lCalendario.ObtenerTodos();

            CollectionAssert.AreNotEquivalent(lResultadoEsperado, lResultado);

        }

        #endregion
        #region ObtenerOrdenadosPor Test
        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodAscSort()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento4, lEvento3, lEvento1, lEvento2 };
            List<Evento> lResultado = new List<Evento>();

            IComparer<Evento> lComparador = new EventCodeAscendingComparer();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithCodDescSort()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento2, lEvento1, lEvento3, lEvento4 };
            List<Evento> lResultado = new List<Evento>();

            IComparer<Evento> lComparador = new EventCodeDescendingComparer();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithTitleAscSort()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento4, lEvento3, lEvento1, lEvento2 };
            List<Evento> lResultado = new List<Evento>();

            IComparer<Evento> lComparador = new EventTitleAscendingComparer();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithTitleDescSort()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2, lEvento3, lEvento4 };
            List<Evento> lResultado = new List<Evento>();

            IComparer<Evento> lComparador = new EventTitleDescendingComparer();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithDateAscSort()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento3, lEvento4, lEvento1, lEvento2 };
            List<Evento> lResultado = new List<Evento>();

            IComparer<Evento> lComparador = new EventDateAscendingComparer();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerOrdenadosPor_WithDateDescSort()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento2, lEvento1, lEvento4, lEvento3 };
            List<Evento> lResultado = new List<Evento>();

            IComparer<Evento> lComparador = new EventDateDescendingComparer();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerOrdenadosPor(lComparador);

            CollectionAssert.AreEqual(lResultadoEsperado, lResultado);

        }
        #endregion
        #region ObtenerPorCriterio Test
        [TestMethod]
        public void ObtenerPorCriterio_WithFrequencyCriterion()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio = new FrequencyCriterion(FrecuenciaRepeticion.Semanal);

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerPorCriterio_WithBeforeDateCriterion()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento3, lEvento4};
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio = new BeforeDateCriterion(new DateTime(2015, 07, 15));

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerPorCriterio_WithAfterDateCriterion()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio = new AfterDateCriterion(new DateTime(2015, 07, 15));

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }


        [TestMethod]
        public void ObtenerPorCriterio_WithDayOfWeekCriterion()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio = new DayOfWeekCriterion(DayOfWeek.Wednesday);

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }


        [TestMethod]
        public void ObtenerPorCriterio_WithAndCriteria()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio1 = new DayOfWeekCriterion(DayOfWeek.Wednesday);
            ICriteria<Evento> lCriterio2 = new FrequencyCriterion(FrecuenciaRepeticion.Semanal);
            ICriteria<Evento> lCriterio3 = lCriterio1.And(lCriterio2);

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio3);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerPorCriterio_WithOrCriteria()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1,lEvento2, lEvento3 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio1 = new DayOfWeekCriterion(DayOfWeek.Monday);
            ICriteria<Evento> lCriterio2 = new FrequencyCriterion(FrecuenciaRepeticion.Semanal);
            ICriteria<Evento> lCriterio3 = lCriterio1.Or(lCriterio2);

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio3);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerPorCriterio_WithNotCriteria()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento4,lEvento3 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio1 = new AfterDateCriterion(new DateTime(2015, 07, 15));
            ICriteria<Evento> lCriterio2 = lCriterio1.Not();

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio2);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }

        [TestMethod]
        public void ObtenerPorCriterio_WithAndOrNotCriteria()
        {
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
            Calendario lCalendario = new Calendario("Unit Testing!", "UT");
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1,lEvento2,lEvento3,lEvento4 };
            List<Evento> lResultado = new List<Evento>();

            ICriteria<Evento> lCriterio1 = new BeforeDateCriterion(new DateTime(2015,08,06));
            ICriteria<Evento> lCriterio2 = new FrequencyCriterion(FrecuenciaRepeticion.Semanal);
            ICriteria<Evento> lCriterio3 = new DayOfWeekCriterion(DayOfWeek.Wednesday);
            ICriteria<Evento> lCriterio = lCriterio2.Or(lCriterio1.And(lCriterio3.Not()));

            lCalendario.Agregar(lEvento1);
            lCalendario.Agregar(lEvento2);
            lCalendario.Agregar(lEvento3);
            lCalendario.Agregar(lEvento4);

            lResultado = (List<Evento>)lCalendario.ObtenerPorCriterio(lCriterio);

            CollectionAssert.AreEquivalent(lResultadoEsperado, lResultado);

        }
        #endregion
        [TestMethod]
        public void Clone()
        {
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
            Calendario lCalendario1 = new Calendario("Unit Testing!", "UT");
            Calendario lCalendario2;
            List<Evento> lResultadoEsperado = new List<Evento> { lEvento1, lEvento2, lEvento3, lEvento4 };
            List<Evento> lResultado1 = new List<Evento>();
            List<Evento> lResultado2 = new List<Evento>();

            lCalendario1.Agregar(lEvento1);
            lCalendario1.Agregar(lEvento2);
            lCalendario1.Agregar(lEvento3);
            lCalendario1.Agregar(lEvento4);

            lEvento1.FechaComienzo = DateTime.Now;
            lEvento2.FechaFin = DateTime.Now;
            lEvento3.Titulo = "Cumpleaños de Martín Arrúa";
            lEvento4.Frecuencia = FrecuenciaRepeticion.Mensual;

            lCalendario2 = lCalendario1.Copiar();

            lResultado1 = (List<Evento>)lCalendario1.ObtenerTodos();
            lResultado2 = (List<Evento>)lCalendario2.ObtenerTodos();

            CollectionAssert.AreEqual(lResultado1, lResultado2);
            CollectionAssert.AreNotEquivalent(lResultadoEsperado, lResultado1);
            CollectionAssert.AreNotEquivalent(lResultadoEsperado, lResultado2);

        }

    }
}

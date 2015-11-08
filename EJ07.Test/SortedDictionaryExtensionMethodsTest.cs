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
    public class SortedDictionaryExtensionMethodsTest
    {

        [TestMethod]
        public void EsIgual_RetusrnsTrue()
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

            SortedDictionary<string, Evento> lDicc1 = new SortedDictionary<string, Evento>();
            SortedDictionary<string, Evento> lDicc2 = new SortedDictionary<string, Evento>();

            String lLlave = "Ramiro";

            lDicc1.Add(lLlave, lEvento1);
            lDicc2.Add(lLlave, lEvento1);

            Assert.IsTrue(lDicc1.EsIgual(lDicc2));

        }

        [TestMethod]
        public void EsIgual_ReturnsFalse()
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

            SortedDictionary<string, Evento> lDicc1 = new SortedDictionary<string, Evento>();
            SortedDictionary<string, Evento> lDicc2 = new SortedDictionary<string, Evento>();

            String lLlave = "Ramiro";

            lDicc1.Add(lLlave, lEvento1);
            lDicc2.Add(lLlave, lEvento2);

            Assert.IsFalse(lDicc1.EsIgual(lDicc2));

        }
    }
}

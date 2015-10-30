using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class LevenshteingDistanceTest
    {
        [TestMethod]
        public void ObtenerPorcentajeUnaSustitucion()
        {
            LevenshteingDistance levenshteing = new LevenshteingDistance("casa", "caza");
            Assert.AreEqual(0.25, levenshteing.Calcular());
        }
    

        [TestMethod]
        public void ObtenerPorcentajeUnaEliminacion()
        {
            LevenshteingDistance levenshteing = new LevenshteingDistance("ola", "hola");
            Assert.AreEqual(0.25, levenshteing.Calcular());
        }

        public void ObtenerPorcentajeUnaInsersion()
        {
            LevenshteingDistance levenshteing = new LevenshteingDistance("hola", "ola");
            Assert.AreEqual(0.25, levenshteing.Calcular());
        }

        public void ObtenerPorcentajeIguales()
        {
            LevenshteingDistance levenshteing = new LevenshteingDistance("casa", "casa");
            Assert.AreEqual(0, levenshteing.Calcular());
        }

        public void ObtenerPorcentajeDiferentes()
        {
            LevenshteingDistance levenshteing = new LevenshteingDistance("hola", "chau");
            Assert.AreEqual(1, levenshteing.Calcular());
        }



    }
}


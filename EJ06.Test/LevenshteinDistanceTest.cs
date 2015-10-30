using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class CalculadorDistanciaLevenshteinTest
    {
        [TestMethod]
        public void ObtenerPorcentajeUnaSustitucion()
        {
            CalculadorDistanciaLevenshtein levenshtein = new CalculadorDistanciaLevenshtein("casa", "caza");
            Assert.AreEqual(0.25, levenshtein.Calcular());
        }
    

        [TestMethod]
        public void ObtenerPorcentajeUnaEliminacion()
        {
            CalculadorDistanciaLevenshtein levenshtein = new CalculadorDistanciaLevenshtein("ola", "hola");
            Assert.AreEqual(0.25, levenshtein.Calcular());
        }

        public void ObtenerPorcentajeUnaInsersion()
        {
            CalculadorDistanciaLevenshtein levenshtein = new CalculadorDistanciaLevenshtein("hola", "ola");
            Assert.AreEqual(0.25, levenshtein.Calcular());
        }

        public void ObtenerPorcentajeIguales()
        {
            CalculadorDistanciaLevenshtein levenshtein = new CalculadorDistanciaLevenshtein("casa", "casa");
            Assert.AreEqual(0, levenshtein.Calcular());
        }

        public void ObtenerPorcentajeDiferentes()
        {
            CalculadorDistanciaLevenshtein levenshtein = new CalculadorDistanciaLevenshtein("hola", "chau");
            Assert.AreEqual(1, levenshtein.Calcular());
        }



    }
}


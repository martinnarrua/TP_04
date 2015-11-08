using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ02;

namespace EJ02.Test
{
    [TestClass]
    public class MatematicaTest
    {
        [TestMethod]
        public void DivisionCorrectaTest()
        {
            int dividendo = 10;
            int divisor = 5;

            Assert.AreEqual(2, Matematica.Dividir(dividendo, divisor));
        }

        [TestMethod]
        public void DivisionPorCeroTest()
        {
            try
            {
                int dividendo = 10;
                int divisor = 0;
                double mResultado = Matematica.Dividir(dividendo, divisor);
                Assert.Fail();

            }
            catch (DivisionPorCeroException) { }
        }
    }
}

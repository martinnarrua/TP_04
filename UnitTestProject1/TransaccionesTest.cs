using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ04;

namespace EJ04.Test
{
    [TestClass]
    public class TransaccionesTest
    {
        [TestMethod]
        public void AcreditarSaldoTest()
        {
            Cuentas cuentas = new Cuentas();
            double saldo = 100;
            cuentas.CuentaEnPesos.AcreditarSaldo(saldo);

            Assert.AreEqual(100, cuentas.CuentaEnPesos.Saldo);
        }

        [TestMethod]
        public void DebitarSaldoTest()
        {
            Cuentas cuentas = new Cuentas();
            double saldo = 100;
            cuentas.CuentaEnPesos.AcreditarSaldo(saldo);
            cuentas.CuentaEnPesos.DebitarSaldo(saldo);

            Assert.AreEqual(0, cuentas.CuentaEnPesos.Saldo);
        }

        [TestMethod]
        public void MontoNegativoExceptionEnAcreditarTest()
        {
            try
            {
                Cuentas cuentas = new Cuentas();
                double saldo = -100;
                cuentas.CuentaEnPesos.AcreditarSaldo(saldo);
                Assert.Fail();
            }
            catch (MontoNegativoException) { }
        }

        [TestMethod]
        public void MontoNegativoExceptionEnDebitarTest()
        {
            try
            {
                Cuentas cuentas = new Cuentas();
                double saldo = -100;
                cuentas.CuentaEnPesos.DebitarSaldo(saldo);
                Assert.Fail();
            }
            catch (MontoNegativoException) { }
        }

       /* [TestMethod]
        public void DesbordamientoExceptionTest()
        {
            try
            {
                Cuentas cuentas = new Cuentas();
                double saldo = double.MaxValue;
                cuentas.CuentaEnPesos.AcreditarSaldo(saldo);
                Assert.Fail();
            }
            catch (DesbordamientoException) {}
        }
        */
        [TestMethod]
        public void SaldoInsuficienteExceptionTest()
        {
            try
            {
                Cuentas cuentas = new Cuentas();
                cuentas.CuentaEnPesos.AcreditarSaldo(100);
                cuentas.CuentaEnPesos.DebitarSaldo(200);
                Assert.Fail();
            }
            catch (SaldoInsuficienteException) { }
        }

    }
}

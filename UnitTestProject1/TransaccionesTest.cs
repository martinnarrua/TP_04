using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ04;

namespace EJ04.Test
{
    [TestClass]
    public class TransaccionesTest
    {
        [TestMethod]
        public void AcreditarSaldo_WithCaminoFeliz()
        {
            Cuentas cuentas = new Cuentas();
            double saldo = 100;
            cuentas.CuentaEnPesos.AcreditarSaldo(saldo);

            Assert.AreEqual(100, cuentas.CuentaEnPesos.Saldo);
        }

        [TestMethod]
        public void DebitarSaldo_WithCaminoFeliz()
        {
            Cuentas cuentas = new Cuentas();
            double saldo = 100;
            cuentas.CuentaEnPesos.AcreditarSaldo(saldo);
            cuentas.CuentaEnPesos.DebitarSaldo(saldo);

            Assert.AreEqual(0, cuentas.CuentaEnPesos.Saldo);
        }

        [TestMethod]
        public void AcreditarSaldo_WithMontoNegativo_Fails()
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
        public void DebitarSaldo_WithMontoNegativo_Fails()
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

       [TestMethod]
        public void AcreditarSaldo_WithSaldoDesbordante_Fails()
        {
            try
            {
                Cuentas cuentas = new Cuentas();
                double saldo = double.MaxValue;
                cuentas.CuentaEnPesos.AcreditarSaldo(10);
                cuentas.CuentaEnPesos.AcreditarSaldo(saldo);
                Assert.Fail();
            }
            catch (DesbordamientoException) {}
        }
        
        [TestMethod]
        public void DebitarSaldo_WithSaldoInsuficiente_Fails()
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

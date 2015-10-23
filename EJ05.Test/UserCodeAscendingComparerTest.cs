using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;

namespace EJ05.Test
{
    [TestClass]
    public class UserCodeAscendingComparerTest
    {
        [TestMethod]
        public void Compare_With0001_0005_Returns1()
        {
            string lNombreCompleto1 = "Ramiro Rivera";
            string lNombreCompleto2 = "Martín Arrúa";
            string lCodigo1 = "0001";
            string lCodigo2 = "0005";
            string lCorreoElectronico1 = "Ramarivera@gmail.com";
            string lCorreoElectronico2 = "Martin94.profugo@hotmail.com";
            int lResultado = 0;
            int lResultadoEsperado = 1;

            Usuario lUsuario1 = new Usuario { Codigo = lCodigo1, NombreCompleto = lNombreCompleto1, CorreoElectronico = lCorreoElectronico1 };
            Usuario lUsuario2 = new Usuario { Codigo = lCodigo2, NombreCompleto = lNombreCompleto2, CorreoElectronico = lCorreoElectronico2 };


            Assert.AreEqual(lResultadoEsperado, lResultado);
        }
    }
}

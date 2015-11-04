using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ06;

namespace EJ06.Test
{
    [TestClass]
    public class UsuarioTest
    {
       

        [TestMethod]
        public void Clone_ReturnsNotEquals()
        {
            string lNombreCompleto1 = "Ramiro Rivera";
            string lNombreCompleto2 = "Martín Arrúa";
            string lCodigo1 = "0001";
            string lCodigo2 = "0005";
            string lCorreoElectronico1 = "Ramarivera@gmail.com";
            string lCorreoElectronico2 = "Martin94.profugo@hotmail.com";
            string lResultadoEsperado = "Ramiro Rivera";

            Usuario lUsuario1 = new Usuario { Codigo = lCodigo1, NombreCompleto = lNombreCompleto1, CorreoElectronico = lCorreoElectronico1 };
            Usuario lUsuario2;

            lUsuario2 = lUsuario1.Clone();

            lUsuario1.Codigo = lCodigo2;
            lUsuario1.CorreoElectronico = lCorreoElectronico2;
            lUsuario1.NombreCompleto = lNombreCompleto2;

            Assert.AreEqual(lResultadoEsperado, lUsuario2.NombreCompleto);

        }

        [TestMethod]
        public void Clone_ReturnsTrue()
        {
            string lNombreCompleto1 = "Ramiro Rivera";
            string lNombreCompleto2 = "Martín Arrúa";
            string lCodigo1 = "0001";
            string lCodigo2 = "0005";
            string lCorreoElectronico1 = "Ramarivera@gmail.com";
            string lCorreoElectronico2 = "Martin94.profugo@hotmail.com";

            Usuario lUsuario1 = new Usuario { Codigo = lCodigo1, NombreCompleto = lNombreCompleto1, CorreoElectronico = lCorreoElectronico1 };
            Usuario lUsuario2 = lUsuario1;
        
            lUsuario1.Codigo = lCodigo2;
            lUsuario1.CorreoElectronico = lCorreoElectronico2;
            lUsuario1.NombreCompleto = lNombreCompleto2;

            Assert.AreEqual(lUsuario1.Codigo, lUsuario2.Codigo);
            Assert.AreEqual(lUsuario1.CorreoElectronico, lUsuario2.CorreoElectronico);
            Assert.AreEqual(lUsuario1.NombreCompleto, lUsuario2.NombreCompleto);

        }

       
    }
}

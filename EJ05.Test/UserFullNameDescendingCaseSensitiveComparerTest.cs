using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

namespace EJ05.Test
{
    [TestClass]
    public class UserFullNameDescendingCaseSensitiveComparerTest
    {

        [TestMethod]
        public void Compare_With_ramiro_Ramiro_ReturnsMAyor()
        {
            string lNombreCompleto1 = "Ramiro Rivera";
            string lNombreCompleto2 = "ramiro rivera";
            string lCodigo1 = "0001";
            string lCodigo2 = "0005";
            string lCorreoElectronico1 = "Ramarivera@gmail.com";
            string lCorreoElectronico2 = "Martin94.profugo@hotmail.com";
            int lResultado;
            int lResultadoEsperado = 1;

            Usuario lUsuario1 = new Usuario { Codigo = lCodigo1, NombreCompleto = lNombreCompleto1, CorreoElectronico = lCorreoElectronico1 };
            Usuario lUsuario2 = new Usuario { Codigo = lCodigo2, NombreCompleto = lNombreCompleto2, CorreoElectronico = lCorreoElectronico2 };
            IComparer<Usuario> lComparer = new UserFullNameDescendingCaseSensitiveComparer();

            lResultado = lComparer.Compare(lUsuario2, lUsuario1);

            Assert.AreEqual(lResultadoEsperado, lResultado);
        }

        [TestMethod]
        public void Compare_With_Ramiro_ramiro_ReturnsMwnoe()
        {
            string lNombreCompleto1 = "Ramiro Rivera";
            string lNombreCompleto2 = "ramiro rivera";
            string lCodigo1 = "0007";
            string lCodigo2 = "0004";
            string lCorreoElectronico1 = "Ramarivera@gmail.com";
            string lCorreoElectronico2 = "Martin94.profugo@hotmail.com";
            int lResultado;
            int lResultadoEsperado = -1;

            Usuario lUsuario1 = new Usuario { Codigo = lCodigo1, NombreCompleto = lNombreCompleto1, CorreoElectronico = lCorreoElectronico1 };
            Usuario lUsuario2 = new Usuario { Codigo = lCodigo2, NombreCompleto = lNombreCompleto2, CorreoElectronico = lCorreoElectronico2 };
            IComparer<Usuario> lComparer = new UserFullNameDescendingCaseSensitiveComparer();

            lResultado = lComparer.Compare(lUsuario1, lUsuario2);

            Assert.AreEqual(lResultadoEsperado, lResultado);
        }
    }
}

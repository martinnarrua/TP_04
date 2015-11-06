using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa una excepcion que se arroja cuando el saldo de una <see cref="Cuenta"/> es insuficiente para realizar un debito
    /// </summary>
    public class SaldoInsuficienteException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="SaldoInsuficienteException"/>. Constructor por defecto
        /// </summary>
        public SaldoInsuficienteException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="SaldoInsuficienteException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public SaldoInsuficienteException(string pMensaje): base(pMensaje) { }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa una excepcion que se arroja cuando el saldo actual de una <see cref="Cuenta"/> mas el monto que se desea acreditar genera un desbordamiento.
    /// </summary>
    public class DesbordamientoException : OverflowException
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DesbordamientoException"/>. Constructor por defecto
        /// </summary>
        public DesbordamientoException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DesbordamientoException"/> con un mensaje de error especifico.
        /// </summary>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public DesbordamientoException(string pMensaje) : base(pMensaje) { }

    }
}

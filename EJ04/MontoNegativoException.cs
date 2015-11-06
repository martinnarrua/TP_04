using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa una excepcion que se arroja cuando el monto pasado como parametro a un metodo  de una <see cref="Cuenta"/>es negativo
    /// </summary>
    public class MontoNegativoException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="MontoNegativoException"/>. Constructor por defecto
        /// </summary>
        public MontoNegativoException() : base() { }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="MontoNegativoException"/> con un mensaje de error especifico y el nombre del parametro que causo la excepcion
        /// </summary>
        /// <param name="pNombreParametro">Nombre del parametro que causo la excepcion</param>
        /// <param name="pMensaje">Mensaje que explica la causa de la excepcion</param>
        public MontoNegativoException(string pNombreParametro, string pMensaje) : base(pNombreParametro,pMensaje) { }
    }
}

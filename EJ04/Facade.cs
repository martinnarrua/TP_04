using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Clase Fachada del ejercicio02, abstrae implementaciones de las clases Cuentas, Cuenta y Moneda
    /// </summary>
	class Facade
	{
        /// <summary>
        /// Permite obtener una nueva instancia de la clase Cuentas
        /// </summary>
        /// <returns>Devuelve una nueva instancia de Cuentas</returns>
		public Cuentas CrearCuentas()
		{
			return new Cuentas();
		}

        /// <summary>
        /// Permite acreditar dinero a una cuenta
        /// </summary>
        /// <param name="pCuenta">Cuenta en la que se acreditara el dinero</param>
        /// <param name="pSaldo">Monto a acreditar en la cuenta</param>
		public void AcreditarSaldo (Cuenta pCuenta, double pSaldo)
		{
			pCuenta.AcreditarSaldo(pSaldo);
		}

        /// <summary>
        /// Permite debitar dinero de una <see cref="Cuenta"/>
        /// </summary>
        /// <param name="pCuenta">Cuenta en la que se acreditara el dinero</param>
        /// <param name="pSaldo">Monto a decinar de la cuenta</param>
		public void DebitarSaldo (Cuenta pCuenta, double pSaldo)
		{
			pCuenta.DebitarSaldo(pSaldo);
		}

        /// <summary>
        /// Permite obtener el simbolo de la moneda de una cuenta
        /// </summary>
        /// <param name="pCuenta">Cuenta de la que se quiere conocer el simbolo</param>
        /// <returns>Devuelve el simbolo de la moneda de la cuenta</returns>
		string RecuperarSimbolo (Cuenta pCuenta)
		{
			return pCuenta.Moneda.Simbolo;
		}

        /// <summary>
        /// Permite obtener el saldo de una cuenta
        /// </summary>
        /// <param name="pCuenta">Cuenta de la que se quiere conocer el saldo </param>
        /// <returns>Devuelve el saldo de la cuenta</returns>
		public string RecuperarSaldo (Cuenta pCuenta)
		{
			return this.RecuperarSimbolo(pCuenta) + " " + pCuenta.Saldo.ToString() ;
		}
	}
}

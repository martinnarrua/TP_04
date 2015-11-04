using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Clase Fachada del ejercicio04, abstrae implementaciones de las clases Cuentas, Cuenta y Moneda
    /// </summary>
	class Facade
	{
        private Cuentas iCuentas;

        public Facade()
        {
            this.iCuentas = new Cuentas();
        }

        /// <summary>
        /// Permite acreditar dinero a una <see cref="Cuenta"/>
        /// </summary>
        /// <param name="pCodigoCuenta">Codigo de la <see cref="Cuenta"/> en la que se acreditara el dinero</param>
        /// <param name="pSaldo">Monto a acreditar en la cuenta</param>
        /// <returns>Devuelve un booleano que indica si se pudo acreditar el saldo o no</returns>
		public bool AcreditarSaldo(string pCodigoCuenta, double pSaldo)
        {
            bool lResultado = false;
            Cuenta lCuenta = this.GetCuenta(pCodigoCuenta);
            
            if (lCuenta != null)
            {
                lCuenta.AcreditarSaldo(pSaldo);
                lResultado = true;
            }

            return lResultado;
		}

        /// <summary>
        /// Permite debitar dinero de una <see cref="Cuenta"/>
        /// </summary>
        /// <param name="pCuenta">Codigo de la <see cref="Cuenta"/> en la que se acreditara el dinero</param>
        /// <param name="pSaldo">Monto a debitar de la cuenta</param>
        /// <returns>Devuelve un booleano que indica si se pudo debitar el saldo o no</returns>
		public bool DebitarSaldo (string pCodigoCuenta, double pSaldo)
		{
            bool lResultado = false;
            Cuenta lCuenta = this.GetCuenta(pCodigoCuenta);

            if (lCuenta != null)
            {
                lCuenta.DebitarSaldo(pSaldo);
                lResultado = true;
            }

            return lResultado;
		}
        /*
        /// <summary>
        /// Permite obtener el saldo de una cuenta
        /// </summary>
        /// <param name="pCuenta">Cuenta de la que se quiere conocer el saldo </param>
        /// <returns>Devuelve el saldo de la cuenta</returns>
		public string RecuperarSaldo (Cuenta pCuenta)
		{
			return this.RecuperarSimbolo(pCuenta) + " " + pCuenta.Saldo.ToString() ;
		}
        */
        public Cuenta GetCuenta(String pCodigo)
        {
            Cuenta lCuenta;
            switch (pCodigo)
            {
                case "ARS":
                    lCuenta = iCuentas.CuentaEnPesos;
                    break;
                case "USD":
                    lCuenta = iCuentas.CuentaEnDolares;
                    break;
                default:
                    lCuenta = null;
                    break;
            }
            return lCuenta;
        }
	}
}
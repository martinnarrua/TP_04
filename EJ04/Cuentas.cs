using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa en par de cuentas, una en pesos y otra en dolares
    /// </summary>
	class Cuentas
	{
        /// <summary>
        /// Representa una cuenta en dolares
        /// </summary>
		private Cuenta iCuentaEnDolares;
        /// <summary>
        /// Representa una cuenta en pesos
        /// </summary>
		private Cuenta iCuentaEnPesos;

        /// <summary>
        /// Propiedad CuentaEnDolares, solo lectura
        /// </summary>
		public Cuenta CuentaEnDolares
		{
			get { return this.iCuentaEnDolares; }
			private set { this.iCuentaEnDolares = value; }
		}

        /// <summary>
        /// Propiedad CuentaEnPesos, solo lectura
        /// </summary>
		public Cuenta CuentaEnPesos
		{
			get { return this.iCuentaEnPesos; }
			private set { this.iCuentaEnPesos = value;  }
		}

        /// <summary>
        /// Constructor de la clase
        /// </summary>
		public Cuentas()
		{
			Moneda dolar = new Moneda("USD", "Dolar", "U$S");
			Moneda peso = new Moneda("ARS", "Peso Argentino", "$");
			this.CuentaEnDolares = new Cuenta(dolar);
			this.CuentaEnPesos = new Cuenta(peso);
		}
	}
}

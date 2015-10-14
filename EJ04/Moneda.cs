using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa un tipo de moneda
    /// </summary>
    class Moneda
    {
        /// <summary>
        /// Representa el codigo ISO de la moneda
        /// </summary>
        private string iCodigoISO;
        /// <summary>
        /// Representa el nombre de la moneda
        /// </summary>
        private string iNombre;
        /// <summary>
        /// Representa el simbolo de la moneda
        /// </summary>
        private string iSimbolo;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pCodigoISO">Codigo ISO de la moneda</param>
        /// <param name="pNombre">Nombre de la moneda</param>
        /// <param name="pSimbolo">Simbolo de la moneda</param>
        public Moneda(string pCodigoISO, string pNombre, string pSimbolo)
        {
            this.iCodigoISO = pCodigoISO;
            this.iNombre = pNombre;
            this.iSimbolo = pSimbolo;
        }

        /// <summary>
        /// Propiedad CodigoISO, solo lectura
        /// </summary>
        public string CodigoISO
        {
            get { return this.iCodigoISO; }
            private set { this.iCodigoISO = value; }
        }

        /// <summary>
        /// Propiedad Nombre, solo lectura
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            private set { this.iNombre = value; }
        }

        /// <summary>
        /// Propiedad Simbolo, solo lectura
        /// </summary>
        public string Simbolo
        {
            get { return this.iSimbolo; }
            private set { this.iSimbolo = value; }
        }

    }
}

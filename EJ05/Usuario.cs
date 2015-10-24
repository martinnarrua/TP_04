﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace EJ05
{
    public class Usuario : IComparable
    {
        private string iCodigo;
        private string iNombreCompleto;
        private string iCorreoElectronico;

        public string Codigo
        { 
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        public string NombreCompleto
        {
            get { return this.iNombreCompleto; }
            set { this.iNombreCompleto = value; }
        }

        public string CorreoElectronico
        {
            get { return this.iCorreoElectronico; }
            set { this.iCorreoElectronico = value; }
        }
        /// <summary>
        /// Implementacion de <see cref="IComparable{T}.CompareTo(T)"/>.
        /// Implementa el ordenamiento por defecto para los objetos de la clase <see cref="Usuario"/>
        /// </summary>
        /// <param name="pObj">PObjeto a comparar con el actual</param>
        /// <returns></returns>
        public int CompareTo (object pObj)
        {
            //TODO: Implementacion de Excepciones
            Usuario lUsuario = (Usuario) pObj;
            return (new UserCodeAscendingComparer()).Compare(this, lUsuario);
        }


    }
}

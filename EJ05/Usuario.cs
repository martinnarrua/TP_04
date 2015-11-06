using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace EJ05
{
    /// <summary>
    /// Representa un Usuario dentro de una organzacion.
    /// </summary>
    public class Usuario : IComparable<Usuario>
    {
        /// <summary>
        /// Representa el codigo identificatorio del usuario
        /// </summary>
        private string iCodigo;

        /// <summary>
        /// Almacena el nombre del usuario
        /// </summary>
        private string iNombreCompleto;

        /// <summary>
        /// Almacena el correo electronico del usuario
        /// </summary>
        private string iCorreoElectronico;

        /// <summary>
        /// Propiedad Codigo
        /// </summary>
        public string Codigo
        { 
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Propiedad NombreCompleto
        /// </summary>
        public string NombreCompleto
        {
            get { return this.iNombreCompleto; }
            set { this.iNombreCompleto = value; }
        }

        /// <summary>
        /// Propiedad CorreoElectronico
        /// </summary>
        public string CorreoElectronico
        {
            get { return this.iCorreoElectronico; }
            set { this.iCorreoElectronico = value; }
        }

        /// <summary>
        /// Implementacion de <see cref="IComparable{T}.CompareTo(T)"/>.
        /// Implementa el ordenamiento por defecto para los objetos de la clase <see cref="Usuario"/>
        /// </summary>
        /// <param name="Usuario">Usuario a comparar con el actual</param>
        /// <returns>Valor entero que indica la relacion en el ordenamiento</returns>
        int IComparable<Usuario>.CompareTo(Usuario lUsuario)
        {
            return (new UserCodeAscendingComparer()).Compare(this, lUsuario);
        }
    }
}

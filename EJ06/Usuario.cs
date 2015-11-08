using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EJ06
{
    //[Serializable]
    /// <summary>
    /// Representa un Usuario dentro de una organzacion.
    /// </summary>
    public class Usuario : IComparable<Usuario>, IEquatable<Usuario>
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
        /// Realiza una copia profunda <see cref="Usuario"/>
        /// </summary>
        /// <returns>Copia profunda de <see cref="Usuario"/></returns>
       public Usuario Copiar ()
       {
            Usuario lUsuario = new Usuario();
            lUsuario.Codigo = this.Codigo;
            lUsuario.NombreCompleto = this.NombreCompleto;
            lUsuario.CorreoElectronico = this.CorreoElectronico ;
            return lUsuario;

        }

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
        /// <param name="lUsuario">Usuario a comparar con el actual</param>
        /// <returns></returns>
        int IComparable<Usuario>.CompareTo(Usuario lUsuario)
        {
            return (new UserCodeAscendingComparer()).Compare(this, lUsuario);
        }

        #region Usuario - Metodos Sobrecargados (Equals, ToString, GetHashCode)
        /// <summary>
        /// Sobre carga del metodo ToString()
        /// </summary>
        /// <returns>Representacion como cadena de texto del <see cref="Usuario"/></returns>
        public override string ToString()
        {
            return String.Format("Codigo: {0} \tNombre Completo: {1} \tEmail: {2}", this.Codigo, this.NombreCompleto, this.CorreoElectronico);
        }

        /// <summary>
        /// Sobrecarga del metodo <see cref="object.Equals(object)"/>
        /// </summary>
        /// <param name="obj">Objeto con el que se desea comparar igualdad</param>
        /// <returns>Verdadero o Falso, segun la igualdad del objeto</returns>
        public override bool Equals(object obj)
        {
            // Si obj es (apunta a) null, falso
            if (Object.ReferenceEquals(null, obj))
            {
                return false;
            }
            // Si obj es (apunta a) this, verdadero
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            Usuario lUsuario = obj as Usuario;
            // Si el casteo con As falla, Falso
            if (lUsuario == null)
            {
                return false;
            }

            // Aplico logica particular, casteando previamente a Fecha
            return (this.Codigo == lUsuario.Codigo &&
                    this.NombreCompleto == lUsuario.NombreCompleto &&
                    this.CorreoElectronico == lUsuario.CorreoElectronico);
        }

        /// <summary>
        /// Metodo <see cref="object.Equals(object)"/> para objetos de la clase <see cref="Usuario"/>
        /// </summary>
        /// <param name="pUsuario"><see cref="Usuario"/> con el que se desea comparar por igualdad</param>
        /// <returns>Verdadero o Falso, dependiendo la igualdad de los elementos</returns>
        bool IEquatable<Usuario>.Equals(Usuario pUsuario)
        {
            // Si pUsuario es (apunta a) null, falso
            if (Object.ReferenceEquals(null, pUsuario))
            {
                return false;
            }

            // Si pUsuario es (apunta a) this, verdadero
            if (Object.ReferenceEquals(this, pUsuario))
            {
                return true;
            }

            // Aplico logica particular
            return (this.Codigo == pUsuario.Codigo &&
                   this.NombreCompleto == pUsuario.NombreCompleto &&
                   this.CorreoElectronico == pUsuario.CorreoElectronico);
        }
       
        /// <summary>
        /// Sobrecarga del metodo <see cref="object.GetHashCode()"/>.
        /// </summary>
        /// <returns>Integer HashCode</returns>
        public override int GetHashCode()
        {

            return !Object.ReferenceEquals(null, this) ? this.Codigo.GetHashCode() : 0;
        }

        
        #endregion


    }
}

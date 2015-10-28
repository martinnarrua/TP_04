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
    // [Serializable]
    public class Usuario : IComparable<Usuario>, IEquatable<Usuario>
    {
        private string iCodigo;

        private string iNombreCompleto;

        private string iCorreoElectronico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUnUsuario"></param>
        /// <returns></returns>
       public static Usuario Copiar (Usuario pUnUsuario)
       {
            Usuario lUsuario = new Usuario();
            lUsuario.Codigo = pUnUsuario.Codigo;
            lUsuario.NombreCompleto = pUnUsuario.NombreCompleto;
            lUsuario.CorreoElectronico = pUnUsuario.CorreoElectronico ;
            return lUsuario;

            /*      Otra opcion es usar un metodo Clone que se base en la serializacion del objeto
            public Usuario Clone()
            {
                using (var lMemoryStream = new MemoryStream())
                {
                    var lFormatter = new BinaryFormatter();
                    lFormatter.Serialize(lMemoryStream, this);
                    lMemoryStream.Position = 0;

                    return (Usuario)lFormatter.Deserialize(lMemoryStream);
                }
            } 
            */

        }

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
            return String.Format("Codigo: {0}\tNombre Completo: {1}\tEmail: {2}", this.Codigo, this.NombreCompleto, this.CorreoElectronico);
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
            return (this.Equals(lUsuario));
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
            return (this.Codigo == pUsuario.Codigo) && (this.NombreCompleto == pUsuario.NombreCompleto) && (this.CorreoElectronico == pUsuario.CorreoElectronico);
        }
       
        /// <summary>
        /// Sobrecarga del metodo <see cref="object.GetHashCode()"/>.
        /// </summary>
        /// <returns>Integer HashCode</returns>
        public override int GetHashCode()
        {
            // El HashCode debe ser rapido de calcular y con pocas colisiones
            // Buscamos grandes productos semi-aleatorios, por lo tanto somos concientes de que un overflow de integers es posible, el cual no nos afecta
            unchecked
            {
                // Un gran numero primo disminuye las colisiones en grandes conjuntos de objetos
                const int HashingBase = (int)2166136261; //Primo01, casteado a int
                const int HashingMultiplier = 16777619; //Primo02

                int hash = HashingBase;
                //Utilizamos cada propiedad de nuestro objeto, si dicha propiedad es nula, el resultado es 0
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.Codigo) ? this.Codigo.GetHashCode() : 0);
                //Sucesivamente vamos acumulando los resultados
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.NombreCompleto) ? this.NombreCompleto.GetHashCode() : 0);
                //Por ultimo en vez de usar +, usamos el operador XOR ^ para obtener una implementacion mas performante
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, this.CorreoElectronico) ? this.CorreoElectronico.GetHashCode() : 0);
                return hash;
            }
        }

        
        #endregion


    }
}

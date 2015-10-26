using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace EJ06
{
    /// <summary>
    /// Comparador Nulo de <see cref="Usuario"/>. Al utilizarse no afecta el ordenamiento actual.
    /// Implementacion del patron Null Object
    /// </summary>
    internal class UserNullComparer : IComparer<Usuario>
    {
        /// <summary>
        /// Compara dos <see cref="Usuario"/>
        /// </summary>
        /// <param name="pUsuario1">Primer <see cref="Usuario"/></param>
        /// <param name="pUsuario2">Segundo <see cref="Usuario"/></param>
        /// <returns> 0, independientemente de los usuarios pasados como parametro</returns>
        public int Compare(Usuario pUsuario1, Usuario pUsuario2)
        {
            return 0;      
        }

    }
}

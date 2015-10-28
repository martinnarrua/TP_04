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
    /// Comparador de <see cref="Usuario"/> por nombre completo, utilizandose para un ordenamiento por nombre completo en orden alfabetico
    /// </summary>
    internal class UserFullNameAscendingCaseSensitiveComparer : IComparer<Usuario>
    {
        /// <summary>
        /// Compara dos <see cref="Usuario"/> segun su nombre completo, teniendo en cuenta la cultura actual y la capitalizacion
        /// </summary>
        /// <param name="pUsuario1">Primer <see cref="Usuario"/></param>
        /// <param name="pUsuario2">Segundo <see cref="Usuario"/></param>
        /// <returns>0 si los usuarios ocupan la misma posicion en el ordenamiento.
        /// Mayor a 1 si Usuario1 es posterior a Usuario2 en el ordenamiento
        /// Menor a 1 si Usuario1 es anterior a Usuario2 en el ordenamiento
        /// </returns>
        public int Compare(Usuario pUsuario1, Usuario pUsuario2)
        {
            return String.Compare(pUsuario1.NombreCompleto, pUsuario2.NombreCompleto, false, Thread.CurrentThread.CurrentCulture);
        }

    }
}

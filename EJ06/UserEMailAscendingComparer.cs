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
    /// Comparador de <see cref="Usuario"/> por correo electronico, utilizandose para un ordenamiento por correo electronico en orden alfabetico
    /// </summary>
    internal class UserEmailAscendingComparer : IComparer<Usuario>
    {
        /// <summary>
        /// Compara dos <see cref="Usuario"/> segun su correo electronico, teniendo en cuenta la cultura actual e ignorando la capitalizacion
        /// </summary>
        /// <param name="pUsuario1">Primer <see cref="Usuario"/></param>
        /// <param name="pUsuario2">Segundo <see cref="Usuario"/></param>
        /// <returns>0 si los usuarios ocupan la misma posicion en el ordenamiento.
        /// Mayor a 1 si Usuario1 es posterior a Usuario2 en el ordenamiento
        /// Menor a 1 si Usuario1 es anterior a Usuario2 en el ordenamiento
        /// </returns>
        public int Compare(Usuario pUsuario1, Usuario pUsuario2)
        {
            return String.Compare(pUsuario1.CorreoElectronico, pUsuario2.CorreoElectronico, true, Thread.CurrentThread.CurrentCulture);
        }

    }
}

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
    /// Comparador de <see cref="Usuario"/> por codigo, utilizandose para un ordenamiento por codigo ascendente
    /// </summary>
    internal class UserCodeAscendingComparer : IComparer<Usuario>
    {
        /// <summary>
        /// Compara dos <see cref="Usuario"/> segun su codigo, teniendo en cuenta la cultura actual e ignorando la capitalizacion
        /// </summary>
        /// <param name="pUsuario1">Primer <see cref="Usuario"/></param>
        /// <param name="pUsuario2">Segundo <see cref="Usuario"/></param>
        /// <returns>0 si los usuarios ocupan la misma posicion en el ordenamiento.
        /// Mayor a 1 si Usuario1 es posterior a Usuario2 en el ordenamiento
        /// Menor a 1 si Usuario1 es anterior a Usuario2 en el ordenamiento
        /// </returns>
        public int Compare(Usuario pUsuario1, Usuario pUsuario2)
        {
            if (pUsuario1== null && pUsuario2==null)
            {
                return 0;
            }
            else if (pUsuario1 == null)
            {
                return -1;
            }
            else if (pUsuario2 == null)
            {
                return 1;
            }
            return String.Compare(pUsuario1.Codigo, pUsuario2.Codigo, true, Thread.CurrentThread.CurrentCulture);        
        }

    }
}

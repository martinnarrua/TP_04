﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EJ06.Comparers
{
    /// <summary>
    /// Comparador de <see cref="Usuario"/> por nombre completo, utilizandose para un ordenamiento por nombre completo en orden alfabetico
    /// </summary>
    public class UserFullNameAscendingNeutralCultureCaseSensitiveComparer : IComparer<Usuario>
    {
        /// <summary>
        /// Compara dos <see cref="Usuario"/> segun su nombre completo, teniendo en cuenta la capitalizacion e ignorando informacion de la cultura actual
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
            return String.Compare(pUsuario1.NombreCompleto, pUsuario2.NombreCompleto, false);
        }

    }
}


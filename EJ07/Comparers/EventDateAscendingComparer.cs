﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace EJ07.Comparers
{
    /// <summary>
    /// Comparador de <see cref="Evento"/> por fecha de creacion, utilizandose para un ordenamiento por fecha de creacion ascendente
    /// </summary>
    public class EventDateAscendingComparer : IComparer<Evento>
    {
        /// <summary>
        /// Compara dos <see cref="Evento"/> segun su fecha de creacion
        /// </summary>
        /// <param name="pEvento1">Primer <see cref="Evento"/></param>
        /// <param name="pEvento2">Segundo <see cref="Evento"/></param>
        /// <returns>0 si los eventos ocupan la misma posicion en el ordenamiento.
        /// Mayor a 1 si Evento1 es posterior a Evento2 en el ordenamiento
        /// Menor a 1 si Evento1 es anterior a Evento2 en el ordenamiento
        /// </returns>
        public int Compare(Evento pEvento1, Evento pEvento2)
        {
            if (pEvento1 == null && pEvento2 == null)
            {
                return 0;
            }
            else if (pEvento1 == null)
            {
                return -1;
            }
            else if (pEvento2 == null)
            {
                return 1;
            }
            return DateTime.Compare(pEvento1.FechaComienzo, pEvento2.FechaComienzo);
        }

    }
}

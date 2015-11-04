using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;


namespace EJ07.Comparers
{
    /// <summary>
    /// Comparador de <see cref="Calendario"/> por fecha de creacion, utilizandose para un ordenamiento por fecha de creacion descendente
    /// </summary>
    internal class CalendarDateDescendingComparer : IComparer<Calendario>
    {
        /// <summary>
        /// Compara dos <see cref="Calendario"/> segun su fecha de creacion
        /// </summary>
        /// <param name="pCalendario1">Primer <see cref="Calendario"/></param>
        /// <param name="pCalendario2">Segundo <see cref="Calendario"/></param>
        /// <returns>0 si los calendarios ocupan la misma posicion en el ordenamiento.
        /// Mayor a 1 si Calendario1 es anterior a Calendario2 en el ordenamiento
        /// Menor a 1 si Calendario1 es posterior a Calendario2 en el ordenamiento
        /// </returns>
        public int Compare(Calendario pCalendario1, Calendario pCalendario2)
        {
            return (-1) * ((new CalendarDateAscendingComparer()).Compare(pCalendario1, pCalendario2));
        }

    }
}


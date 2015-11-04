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
    /// Comparador de <see cref="Calendario"/> por titulo, utilizandose para un ordenamiento por titulo descendente
    /// </summary>
    internal class CalendarTitleDescendingComparer : IComparer<Calendario>
    {
        /// <summary>
        /// Compara dos <see cref="Calendario"/> segun su titulo, teniendo en cuenta la cultura actual e ignorando la capitalizacion
        /// </summary>
        /// <param name="pCalendario1">Primer <see cref="Calendario"/></param>
        /// <param name="pCalendario2">Segundo <see cref="Calendario"/></param>
        /// <returns>0 si los calendarios ocupan la misma posicion en el ordenamiento.
        /// Mayor a 1 si Calendario1 es anterior a Calendario2 en el ordenamiento
        /// Menor a 1 si Calendario1 es posterior a Calendario2 en el ordenamiento
        /// </returns>
        public int Compare(Calendario pCalendario1, Calendario pCalendario2)
        {
            return (-1) * ((new CalendarTitleAscendingComparer()).Compare(pCalendario1, pCalendario2));
        }

    }
}

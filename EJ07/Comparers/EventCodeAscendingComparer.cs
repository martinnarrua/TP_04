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
    /// Comparador de <see cref="Evento"/> por codigo, utilizandose para un ordenamiento por codigo ascendente
    /// </summary>
    public class EventCodeAscendingComparer : IComparer<Evento>
    {
        /// <summary>
        /// Compara dos <see cref="Evento"/> segun su codigo, teniendo en cuenta la cultura actual e ignorando la capitalizacion
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
            return String.Compare(pEvento1.Codigo, pEvento2.Codigo, true, Thread.CurrentThread.CurrentCulture);
        }

    }
}

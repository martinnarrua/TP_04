using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Helpers
{
    public static class SortedDictionaryExtensionMethods
    {
        public static bool EsIgual<T, L>(this SortedDictionary<T, L> pDicc1, SortedDictionary<T, L> pDicc2)
        {
            return pDicc1.Count == pDicc2.Count && !pDicc1.Except(pDicc2).Any();
            // Dos diccionarios son iguales si tienen la misma cantidad de pares llave valor y
            // si no hay ningun par que este en uno pero no en el otro
        }
    }

}

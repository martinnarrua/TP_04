using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria
{

    internal class NotCriteria<T> : ICriteria<T>
    {
        private readonly ICriteria<T> iCriterio;

        internal NotCriteria(ICriteria<T> pCriterio)
        {
            this.iCriterio = pCriterio;
        }

        IList<T> ICriteria<T>.SatisfacenCriterio(IList<T> pEntidades)
        {
            IList<T> lSatisfacenCriterio = this.iCriterio.SatisfacenCriterio(pEntidades);
            // ensure original list is not modified, otherwise compound Or will use an already filtered list
            IList<T> lNoSatisfacenCriterio = pEntidades.ToList();

            foreach (T pEntidad in lSatisfacenCriterio)
            {
                lNoSatisfacenCriterio.Remove(pEntidad);
            }

            return lNoSatisfacenCriterio;
        }
    }
}

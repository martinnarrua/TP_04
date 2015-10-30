using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria
{
    internal class AndCriteria<T> : ICriteria<T>
    {
        private readonly ICriteria<T> iUnCriterio;
        private readonly ICriteria<T> iOtroCriterio;

        internal AndCriteria(ICriteria<T> pUnCriterio, ICriteria<T> pOtroCriterio)
        {
            this.iUnCriterio = pUnCriterio;
            this.iOtroCriterio = pOtroCriterio;
        }

        IList<T> ICriteria<T>.SatisfacenCriterio(IList<T> pEntidades)
        {
            IList<T> lResultadoPrimerCriterio = this.iUnCriterio.SatisfacenCriterio(pEntidades);

            if (lResultadoPrimerCriterio.Count == 0)
                return lResultadoPrimerCriterio;

            return this.iOtroCriterio.SatisfacenCriterio(lResultadoPrimerCriterio);
        }
    }
}

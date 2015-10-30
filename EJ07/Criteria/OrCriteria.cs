using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria
{
    internal class OrCriteria<T> : ICriteria<T>
    {
        private readonly ICriteria<T> iUnCriterio;
        private readonly ICriteria<T> iOtroCriterio;

        internal OrCriteria(ICriteria<T> pUnCriterio, ICriteria<T> pOtroCriterio)
        {
            this.iUnCriterio = pUnCriterio;
            this.iOtroCriterio = pOtroCriterio;
        }

        IList<T> ICriteria<T>.SatisfacenCriterio(IList<T> pEntidades)
        {
            IList<T> lResultadoPrimerCriterio = this.iUnCriterio.SatisfacenCriterio(pEntidades);
            IList<T> lResultadoSegundoCriterio = this.iOtroCriterio.SatisfacenCriterio(pEntidades);

            foreach (T pEntidad in lResultadoSegundoCriterio)
            {
                if (!lResultadoPrimerCriterio.Contains(pEntidad))
                    lResultadoPrimerCriterio.Add(pEntidad);
            }

            return lResultadoPrimerCriterio;
        }
    }
}

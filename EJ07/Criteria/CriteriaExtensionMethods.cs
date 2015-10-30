using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria
{
    public static class CriteriaExtensionMethods
    {
        public static ICriteria<T> And<T>(this ICriteria<T> pUnCriterio, ICriteria<T> pOtroCriterio)
        {
            return new AndCriteria<T>(pUnCriterio, pOtroCriterio);
        }

        public static ICriteria<T> Or<T>(this ICriteria<T> pUnCriterio, ICriteria<T> pOtroCriterio)
        {
            return new OrCriteria<T>(pUnCriterio, pOtroCriterio);
        }

        public static ICriteria<T> Not<T>(this ICriteria<T> pUnCriterio)
        {
            return new NotCriteria<T>(pUnCriterio);
        }
    }
}

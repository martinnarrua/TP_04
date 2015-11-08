using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria.Criterion
{
    public class AfterDateCriterion : ICriteria<Evento>
    {
        private DateTime iFecha;

        public AfterDateCriterion(DateTime pFecha)
        {
            iFecha = pFecha;
        }


        IList<Evento> ICriteria<Evento>.SatisfacenCriterio(IList<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                             where ent.FechaComienzo >= this.iFecha
                             select ent;

            return lResultado.ToList();
        }
    }
}

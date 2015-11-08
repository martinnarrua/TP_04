using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria.Criterion
{
    public class FrequencyCriterion : ICriteria<Evento>
    {
        private FrecuenciaRepeticion iFrecuencia;

        public FrequencyCriterion(FrecuenciaRepeticion pFrecuencia)
        {
            iFrecuencia = pFrecuencia;
        }


        IList<Evento> ICriteria<Evento>.SatisfacenCriterio(IList<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                             where ent.Frecuencia == this.iFrecuencia
                             select ent;

            return lResultado.ToList();
        }
    }
}

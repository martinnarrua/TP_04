using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria.Criterion
{
    class DayOfWeekCriterion : ICriteria<Evento>
    {
        private DayOfWeek iDiaSemana;

        public DayOfWeekCriterion(DayOfWeek pDia)
        {
            this.iDiaSemana = pDia;
        }

        IList<Evento> ICriteria<Evento>.SatisfacenCriterio(IList<Evento> pEntidades)
        {
            var lResultado = from ent in pEntidades
                            where ent.FechaComienzo.DayOfWeek == iDiaSemana
                            select ent;

            return (IList<Evento>)lResultado;

        }
    }
}

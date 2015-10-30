using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07.Criteria
{
    public interface ICriteria<T>
    {
        IList<T> SatisfacenCriterio(IList<T> pEntidades);
    }
}

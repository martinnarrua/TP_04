using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ07
{
    public interface IRepositorioCalendarios
    {
        void Agregar(Calendario pCalendario);

        void Actualizar(Calendario pCalendario);

        void Eliminar(string pTitulo);

        IList<Calendario> ObtenerTodos();

        Calendario ObtenerPorNombre(string pNombre);

        IList<Calendario> ObtenerOrdenadosPor(IComparer<Calendario> pComparador);

        IList<Calendario> ObtenerPorCriterio(ICriteria<Calendario> pCriterio);
    }
}

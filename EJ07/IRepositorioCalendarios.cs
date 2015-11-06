using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ07.Criteria;

namespace EJ07
{
    /// <summary>
    /// Interfaz para los . Define operaciones comunes a los mismos
    /// </summary>
    public interface IRepositorioCalendarios
    {
        void Agregar(Calendario pCalendario);

        void Actualizar(Calendario pCalendario);

        void Eliminar(string pTitulo);

        IList<Calendario> ObtenerTodos();

        Calendario ObtenerPorCodigo(string pCodigo);

        IList<Calendario> ObtenerOrdenadosPor(IComparer<Calendario> pComparador);

        IList<Calendario> ObtenerPorCriterio(ICriteria<Calendario> pCriterio);
    }
}

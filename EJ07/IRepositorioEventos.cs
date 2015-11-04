using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ07.Criteria;

namespace EJ07
{
    public interface IRepositorioEventos
    {
        void Agregar(Evento pEvento);

        void Actualizar(Evento pEvento, Evento pEventoModificado);

        void Eliminar(string pTitulo);

        IList<Evento> ObtenerTodos();

        Evento ObtenerPorCodigo(string pCodigo);

        IList<Evento> ObtenerOrdenadosPor(IComparer<Evento> pComparador);

        IList<Evento> ObtenerPorCriterio(ICriteria<Evento> pCriterio);
    }
    
}

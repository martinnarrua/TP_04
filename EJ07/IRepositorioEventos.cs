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
        void Agregar(Evento pEvento, Calendario pCalendario);

        void Actualizar(Evento pEvento, Evento pEventoModificado, Calendario pCalendario);

        void Eliminar(string pTitulo, Calendario pCalendario);

        IList<Evento> ObtenerTodos();

        Evento ObtenerPorNombre(string pCodigo);

        IList<Evento> ObtenerOrdenadosPor(IComparer<Evento> pComparador);

        IList<Evento> ObtenerPorCriterio(ICriteria<Evento> pCriterio);
    }
    
}

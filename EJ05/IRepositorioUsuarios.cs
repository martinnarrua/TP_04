using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ05
{
    public interface IRepositorioUsuarios
    {
        void Agregar(Usuario pUsuario);

        void Actualizar(Usuario pUsuario);

        void Eliminar(string pCodigo);

        IList<Usuario> ObtenerTodos();

        Usuario ObtenerPorCodigo(string pCodigo);

        IList<Usuario> ObtenerOrdenadosPor(IComparer<Usuario> pComparador);
    }
}

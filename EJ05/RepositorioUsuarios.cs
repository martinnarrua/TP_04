using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ05
{
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        private SortedDictionary<string, Usuario> iUsuarios;

        public RepositorioUsuarios()
        {
            iUsuarios = new SortedDictionary<string, Usuario>();
        }
        void IRepositorioUsuarios.Agregar(Usuario pUsuario)
        {
            iUsuarios.Add(pUsuario.Codigo, pUsuario);
        }

        void IRepositorioUsuarios.Actualizar(Usuario pUsuario)
        {
            if (iUsuarios.ContainsKey(pUsuario.Codigo))
            {
                iUsuarios[pUsuario.Codigo] = pUsuario;
            }
            else
            {
                Exception excepcion = new Exception(String.Format("Usuario con el codigo {0} no encontrado", pUsuario.Codigo));
            }
        }

        void IRepositorioUsuarios.Eliminar(string pCodigo)
        {
            if (iUsuarios.ContainsKey(pCodigo))
            {
                iUsuarios.Remove(pCodigo);
            }
            else
            {
                Exception excepcion = new Exception(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
            }
        }
        IList<Usuario> IRepositorioUsuarios.ObtenerTodos()
        {
            return iUsuarios.Values.ToList();
        }

        public Usuario ObtenerPorCodigo(string pCodigo)
        {
            if (iUsuarios.ContainsKey(pCodigo))
            {
                return iUsuarios[pCodigo];
            }
            else
            {
                Exception excepcion = new Exception(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
                return null; //revisar esto
            }
        }

        IList<Usuario> IRepositorioUsuarios.ObtenerOrdenadosPor(IComparer<Usuario> pComparador)
        {
            List<Usuario> lista = this.o

                return null;
        }
    }
}

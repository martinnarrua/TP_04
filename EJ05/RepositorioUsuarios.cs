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
        public void Agregar(Usuario pUsuario)
        {
            iUsuarios.Add(pUsuario.Codigo, pUsuario);
        }

        public void Actualizar(Usuario pUsuario)
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

        public void Eliminar(string pCodigo)
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
        public IList<Usuario> ObtenerTodos()
        {
            return iUsuarios.Values.ToList();
        }

        public Usuario ObtenerPorCodigo(string pCodigo)
        {
            Usuario lUsuario = null;
            if (iUsuarios.ContainsKey(pCodigo))
            {
                return iUsuarios[pCodigo];
            }
            else
            {
                KeyNotFoundException excepcion = new KeyNotFoundException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
                //revisar esto
                // DOBLEMENTE REVISAR ESTO
            }
            return lUsuario;
        }

        public IList<Usuario> ObtenerOrdenadosPor(IComparer<Usuario> pComparador)
        {
            List<Usuario> lLista = iUsuarios.Values.ToList<Usuario>();
            lLista.Sort(pComparador);
            return lLista;
        }
    }
}

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
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pUsuario.Codigo));
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
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
            }
        }
        public IList<Usuario> ObtenerTodos()
        {
            List<Usuario> lLista = (List<Usuario>) this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }
        
        public Usuario ObtenerPorCodigo(string pCodigo)
        {
            Usuario lUsuario = null;
            if (iUsuarios.ContainsKey(pCodigo))
            {
                lUsuario = iUsuarios[pCodigo];
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
                //revisar esto
                //TODO: DOBLEMENTE REVISAR ESTO
            }
            return lUsuario;
        }

        public IList<Usuario> ObtenerOrdenadosPor(IComparer<Usuario> pComparador)
        {
            List<Usuario> lLista = (List<Usuario>) this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }

        private IList<Usuario> ObtenerSinOrdenar()
        {
            List<Usuario> lLista = this.iUsuarios.Values.ToList();
            return lLista;
        }
    }
}

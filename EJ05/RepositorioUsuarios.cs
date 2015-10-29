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
            this.Usuarios = new SortedDictionary<string, Usuario>();
        }

        private SortedDictionary<string, Usuario> Usuarios
        {
            get { return this.iUsuarios; }
            set { this.iUsuarios = value; }
        }
        private IRepositorioUsuarios AsIRepositorioUsuarios
        {
            get { return this; }
        }

        void IRepositorioUsuarios.Agregar(Usuario pUsuario)
        {
            Usuarios.Add(pUsuario.Codigo, pUsuario);
        }

        void IRepositorioUsuarios.Actualizar(Usuario pUsuario)
        {
            if (Usuarios.ContainsKey(pUsuario.Codigo))
            {
                Usuarios[pUsuario.Codigo] = pUsuario;
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pUsuario.Codigo));
            }
        }

        void IRepositorioUsuarios.Eliminar(string pCodigo)
        {
            if (Usuarios.ContainsKey(pCodigo))
            {
                Usuarios.Remove(pCodigo);
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
            }
        }
        IList<Usuario> IRepositorioUsuarios.ObtenerTodos()
        {
            List<Usuario> lLista = (List<Usuario>) this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }
        
        Usuario IRepositorioUsuarios.ObtenerPorCodigo(string pCodigo)
        {
            Usuario lUsuario = null;

            if (Usuarios.ContainsKey(pCodigo))
            {
                lUsuario = Usuarios[pCodigo];
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
                //revisar esto
                //TODO: DOBLEMENTE REVISAR ESTO
            }
            return lUsuario;
        }

        IList<Usuario> IRepositorioUsuarios.ObtenerOrdenadosPor(IComparer<Usuario> pComparador)
        {
            List<Usuario> lLista = (List<Usuario>) this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }


        private IList<Usuario> ObtenerSinOrdenar()
        {
            List<Usuario> lLista = this.Usuarios.Values.ToList();
            return lLista;
        }
    }
}

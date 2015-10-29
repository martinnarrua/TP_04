using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ06
{
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        private List <Usuario> iUsuarios;

        public RepositorioUsuarios()
        {
            this.Usuarios = new List<Usuario>();
        }

        private List<Usuario> Usuarios
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
            Usuario lUsuario = pUsuario.Copiar();
            this.Usuarios.Add(lUsuario);
        }

        void IRepositorioUsuarios.Actualizar(Usuario pUsuario)
        {
            if (this.Usuarios.Contains(pUsuario))
            {
                int lIndice = this.Usuarios.IndexOf(pUsuario);
                Usuario lUsuario = pUsuario.Copiar();
                this.Usuarios[lIndice] = lUsuario;
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pUsuario.Codigo));
            }
        }

        void IRepositorioUsuarios.Eliminar(string pCodigo)
        {
            Usuario lUsuario = new Usuario() { Codigo = pCodigo, CorreoElectronico = "", NombreCompleto="" };

            if (this.Usuarios.Contains(lUsuario))
            {
                this.Usuarios.Remove(lUsuario);
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
            }
        }
        IList<Usuario> IRepositorioUsuarios.ObtenerTodos()
        {
            List<Usuario> lLista = this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }
        
        Usuario IRepositorioUsuarios.ObtenerPorCodigo(string pCodigo)
        {
            Usuario lResultado = null;
            Usuario lUsuario = new Usuario() { Codigo = pCodigo, CorreoElectronico = "", NombreCompleto = "" };

            if (Usuarios.Contains(lUsuario))
            {
                int lIndice = this.Usuarios.IndexOf(lUsuario);
                lResultado = this.Usuarios[lIndice].Copiar();
            }
            else
            {
                UsuarioNoEncontradoException excepcion = new UsuarioNoEncontradoException(String.Format("Usuario con el codigo {0} no encontrado", pCodigo));
            }
            return lResultado;
        }

        IList<Usuario> IRepositorioUsuarios.ObtenerOrdenadosPor(IComparer<Usuario> pComparador)
        {
            List<Usuario> lLista = this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }


        private List<Usuario> ObtenerSinOrdenar()
        {
            List<Usuario> lLista = new List<Usuario>();

            foreach (Usuario lUser in this.Usuarios)
            {
                lLista.Add(lUser.Copiar());
            }
                
            return lLista;
        }

        public List<Usuario> BusquedaPorAproximacion(string pBusqueda)
        {
            pBusqueda = pBusqueda.ToUpper();
            List<Usuario> lResultado = new List<Usuario>();
            int lPor = 0;

            foreach (Usuario lUsuario in this.Usuarios)
            {
                lPor = LevenshteingDistance.Calcular(pBusqueda,lUsuario.NombreCompleto);
                if (lPor < 1)
                {
                    lResultado.Add(lUsuario.Copiar());
                }
            }

            return lResultado;
        }
    }
}

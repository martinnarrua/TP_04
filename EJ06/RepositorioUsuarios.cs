using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ06.Exceptions;

namespace EJ06
{
    /// <summary>
    /// Representa un repositorio de usuarios.
    /// </summary>
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        /// <summary>
        /// Propiedad Privada Usuarios, lista donde se guardan las instancias de Usuario
        /// </summary>
        private List <Usuario> iUsuarios;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="RepositorioUsuarios"/>
        /// </summary>
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

        /// <summary>
        /// Agrega un <see cref="Usuario"/> al Repositorio
        /// </summary>
        /// <param name="pUsuario">Usuario a agregar</param>
        /// <exception cref="ArgumentNullException">Si el usuario o el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="UsuarioExistenteException">si el usuario ya existe en el repositorio</exception>
        void IRepositorioUsuarios.Agregar(Usuario pUsuario)
        {
            if (pUsuario == null)
            {
                throw (new ArgumentNullException("pUsuario", "No se pudo agregar el usuario, el mismo es invalido"));
            }
            else if (pUsuario.Codigo == null)
            {
                throw (new ArgumentNullException("pUsuario.Codigo", "No se pudo agregar el usuario, el codigo es invalido"));
            }
            else if (pUsuario.Codigo == String.Empty)
            {
                throw (new ArgumentException("pUsuario.Codigo", "No se pudo agregar el usuario, el codigo del mismo no puede ser vacio"));
            }
            else if (this.Usuarios.Contains(pUsuario))
            {
                UsuarioExistenteException lException = new UsuarioExistenteException(String.Format("No se pudo agregar el usuario, ya existe un usuario con el codigo '{0}'", pUsuario.Codigo));
                throw lException;
            }
            Usuarios.Add(pUsuario.Copiar());
        }

        /// <summary>
        /// Actualiza la informacion de un <see cref="Usuario"/> 
        /// </summary>
        /// <param name="pUsuario">Usuario a actualizar</param>
        /// <exception cref="ArgumentNullException">Si el usuario o el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="UsuarioNoEncontradoException">si el usuario no existe en el repositorio</exception>
        void IRepositorioUsuarios.Actualizar(Usuario pUsuario)
        {
            if (pUsuario == null)
            {
                throw (new ArgumentNullException("pUsuario", "No se pudo actualizar el usuario, el mismo es invalido"));
            }
            else if (pUsuario.Codigo == null)
            {
                throw (new ArgumentNullException("pUsuario.Codigo", "No se pudo actualizar el usuario, el codigo es invalido"));
            }
            else if (pUsuario.Codigo == String.Empty)
            {
                throw (new ArgumentException("pUsuario.Codigo", "No se pudo actualizar el usuario, el codigo del mismo no puede ser vacio"));
            }
            else if (!this.Usuarios.Contains(pUsuario))
            {
                UsuarioNoEncontradoException lException = new UsuarioNoEncontradoException(String.Format("No se encontro el usuario con codigo '{0}'", pUsuario.Codigo));
                throw lException;
            }
            this.Usuarios[this.Usuarios.IndexOf(pUsuario)] = pUsuario.Copiar();
        }

        /// <summary>
        /// Elimina un <see cref="Usuario"/> del Repositorio
        /// </summary>
        /// <param name="pCodigo">Codigo del usuario a Eliminar</param>
        /// <exception cref="ArgumentNullException">Si el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="UsuarioNoEncontradoException">si el usuario no existe en el repositorio</exception>
        void IRepositorioUsuarios.Eliminar(string pCodigo)
        {
            Usuario pUsuario = new Usuario() { NombreCompleto = "", Codigo = pCodigo, CorreoElectronico = "" };
            if (pCodigo == null)
            {
                throw (new ArgumentNullException("pCodigo", "No se pudo eliminar el usuario, el codigo es invalido"));
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("Codigo", "No se pudo eliminar el usuario, el codigo del mismo no puede ser vacio"));
            }
            else if (!this.Usuarios.Contains(pUsuario))
            {
                UsuarioNoEncontradoException lException = new UsuarioNoEncontradoException(String.Format("No se encontro el usuario con codigo '{0}'", pCodigo));
                throw lException;
            }
            this.Usuarios.RemoveAt(this.Usuarios.IndexOf(pUsuario));
      
        }
        /// <summary>
        /// Obtiene todos las instancias de <see cref="Usuario"/> contenidas en el repositorio
        /// </summary>
        /// <returns>Lista de todos los usuarios</returns>
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
        /*
        public List<Usuario> BusquedaPorAproximacion(string pBusqueda)
        {
            pBusqueda = pBusqueda.ToUpper();
            List<Usuario> lResultado = new List<Usuario>();
            double lPor = 0;
            double min = 1;
            double distancia;

            foreach (Usuario lUsuario in this.Usuarios)
            {
                CalculadorDistanciaLevenshtein lCalculadorDistancia = new CalculadorDistanciaLevenshtein(pBusqueda, lUsuario.NombreCompleto);
                lPor = lCalculadorDistancia.Calcular(out distancia);
                if (lPor < 1)
                {
                    if (lPor < min)
                    {
                        min = lPor;
                        lResultado.Clear() ;
                    }
                    if(lPor == min)
                    {
                        lResultado.Add(lUsuario.Copiar());
                    }
                }
            }
            return lResultado;
        }
        */
        
        public List<Usuario> BusquedaPorAproximacion(string pBusqueda)
        {
            Dictionary<double, Usuario> lResultadoParcial = new Dictionary<double, Usuario>();
            List<Usuario> lResultado = new List<Usuario>();
            double lPor = 0;
            double suma =0;
            foreach (Usuario lUsuario in this.Usuarios)
            {
                CalculadorDistanciaLevenshtein lCalculadorDistancia = new CalculadorDistanciaLevenshtein(pBusqueda, lUsuario.NombreCompleto);
                lPor = lCalculadorDistancia.Calcular();
                if (lPor < 1)
                {
                    lResultadoParcial.Add(lPor,lUsuario.Copiar());
                }
            }
            foreach (double por in lResultadoParcial.Keys)
            {
                suma += por;
            }
            double prom = suma / lResultadoParcial.Count;
            foreach (KeyValuePair<double, Usuario> Par in lResultadoParcial)
            {
                if (Par.Key < prom)
                {
                    lResultado.Add(Par.Value);
                }
            }
            return lResultado;
        }
        
    }
}

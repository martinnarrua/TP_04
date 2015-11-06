using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ05.Exceptions;

namespace EJ05
{
    /// <summary>
    /// Representa un repositorio de usuarios.
    /// </summary>
    public class RepositorioUsuarios: IRepositorioUsuarios
    {
        /// <summary>
        /// Propiedad Privada Usuarios, diccionario donde se guardan los pares Codigo,Usuario
        /// </summary>
        private SortedDictionary<string, Usuario> Usuarios { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="RepositorioUsuarios"/>
        /// </summary>
        public RepositorioUsuarios()
        {
            this.Usuarios = new SortedDictionary<string, Usuario>();
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
            else if (this.Usuarios.ContainsKey(pUsuario.Codigo))
            {
                UsuarioExistenteException lException = new UsuarioExistenteException(String.Format("No se pudo agregar el usuario, ya existe un usuario con el codigo '{0}'", pUsuario.Codigo));
                throw lException;
            }
            this.Usuarios.Add(pUsuario.Codigo, pUsuario);
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
            else if (! this.Usuarios.ContainsKey(pUsuario.Codigo))
            {
                UsuarioNoEncontradoException lException = new UsuarioNoEncontradoException(String.Format("No se encontro el usuario con codigo '{0}'", pUsuario.Codigo));
                throw lException;
            }
                this.Usuarios[pUsuario.Codigo] = pUsuario;
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
            if (pCodigo == null)
            {
                throw (new ArgumentNullException("pCodigo", "No se pudo eliminar el usuario, el codigo es invalido"));
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("Codigo", "No se pudo eliminar el usuario, el codigo del mismo no puede ser vacio"));
            }
            else if (! this.Usuarios.ContainsKey(pCodigo))
            {
                UsuarioNoEncontradoException lException = new UsuarioNoEncontradoException(String.Format("No se encontro el usuario con codigo '{0}'", pCodigo));
                throw lException;
            }
            this.Usuarios.Remove(pCodigo);
        }

        /// <summary>
        /// Obtiene todos las instancias de <see cref="Usuario"/> contenidas en el repositorio
        /// </summary>
        /// <returns>Lista de todos los usuarios</returns>
        IList<Usuario> IRepositorioUsuarios.ObtenerTodos()
        {
            List<Usuario> lLista = (List<Usuario>) this.ObtenerSinOrdenar();
            lLista.Sort();
            return lLista;
        }

        /// <summary>
        /// Permite obtener la instancia de <see cref="Usuario"/> cuyo codigo es igual a <paramref name="pCodigo"/>
        /// </summary>
        /// <param name="pCodigo">Codigo del usuario que se desea obtener</param>
        /// <returns>null  si no se encontro el usuario, el usuario en caso contrario</returns>
        /// <exception cref="ArgumentNullException">Si el codigo es null</exception>
        /// <exception cref="ArgumentException">si el codigo es el string vacio</exception>
        /// <exception cref="UsuarioNoEncontradoException">si el usuario no existe en el repositorio</exception>
        Usuario IRepositorioUsuarios.ObtenerPorCodigo(string pCodigo)
        {
            if (pCodigo == null)
            {
                throw (new ArgumentNullException("pCodigo", "No se pudo obtener el usuario, el codigo es invalido"));
            }
            else if (pCodigo == String.Empty)
            {
                throw (new ArgumentException("Codigo", "No se pudo oteber el usuario, el codigo no puede ser vacio"));
            }
            else if (!this.Usuarios.ContainsKey(pCodigo))
            {
                UsuarioNoEncontradoException lException = new UsuarioNoEncontradoException(String.Format("No se encontro el usuario con codigo '{0}'", pCodigo));
                throw lException;
            }
            return Usuarios[pCodigo];
        }

        /// <summary>
        /// Obtiene ordenadas las instancias de <see cref="Usuario"/> contenidas en el repositorio
        /// </summary>
        /// <param name="pComparador">Implementador de <see cref="IComparer{Usuario}"/>, el cual define el criterio del ordenamiento</param>
        /// <returns>Lista de todos los usuarios ordenados</returns>
        IList<Usuario> IRepositorioUsuarios.ObtenerOrdenadosPor(IComparer<Usuario> pComparador)
        {
            List<Usuario> lLista = (List<Usuario>) this.ObtenerSinOrdenar();
            lLista.Sort(pComparador);
            return lLista;
        }

        /// <summary>
        /// Permite obtener una lista de todos los <see cref="Usuario"/>, sin ordenar
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        private IList<Usuario> ObtenerSinOrdenar()
        {
            List<Usuario> lLista = this.Usuarios.Values.ToList();
            //TODO: Ver si cuando el diccionario no tiene nada values que devuelve, porque si devuelve null estamos al hornix
            return lLista;
        }
    }
}

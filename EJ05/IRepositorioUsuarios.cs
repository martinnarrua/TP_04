using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ05
{
    /// <summary>
    /// Interfaz para los Repositorios de Usuarios. Define operaciones comunes a los mismos
    /// </summary>
    public interface IRepositorioUsuarios
    {
        /// <summary>
        /// Agrega un <see cref="Usuario"/> al Repositorio
        /// </summary>
        /// <param name="pUsuario">Usuario a agregar</param>
        void Agregar(Usuario pUsuario);

        /// <summary>
        /// Actualiza la informacion de un <see cref="Usuario"/> 
        /// </summary>
        /// <param name="pUsuario">Usuario a actualizar</param>
        void Actualizar(Usuario pUsuario);

        /// <summary>
        /// Elimina un <see cref="Usuario"/>
        /// </summary>
        /// <param name="pCodigo">Codigo del usuario a Eliminar</param>
        void Eliminar(string pCodigo);

        /// <summary>
        /// Obtiene todos las instancias de <see cref="Usuario"/> contenidas en el repositorio
        /// </summary>
        /// <returns>Lista de todos los usuarios</returns>
        IList<Usuario> ObtenerTodos();

        /// <summary>
        /// Permite obtener la instancia de <see cref="Usuario"/> cuyo codigo es igual a <paramref name="pCodigo"/>
        /// </summary>
        /// <param name="pCodigo">Codigo del usuario que se desea obtener</param>
        /// <returns>null  si no se encontro el usuario, el usuario en caso contrario</returns>
        Usuario ObtenerPorCodigo(string pCodigo);

        /// <summary>
        /// Obtiene ordenadas las instancias de <see cref="Usuario"/> contenidas en el repositorio
        /// </summary>
        /// <param name="pComparador">Implementador de <see cref="IComparer{Usuario}"/>, el cual define el criterio del ordenamiento</param>
        /// <returns>Lista de todos los usuarios ordenados</returns>
        IList<Usuario> ObtenerOrdenadosPor(IComparer<Usuario> pComparador);
    }
}

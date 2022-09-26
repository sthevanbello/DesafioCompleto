using Desafio.Models;
using System.Collections.Generic;

namespace Desafio.Interfaces
{
    /// <summary>
    /// Interface de UsuarioRepository implementando a interface base com os métodos básicos.
    /// <para>Há também dois métodos Get personalizados</para> 
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        public ICollection<Usuario> GetUsuariosPacientes();
        public ICollection<Usuario> GetUsuariosMedicos();
    }
}

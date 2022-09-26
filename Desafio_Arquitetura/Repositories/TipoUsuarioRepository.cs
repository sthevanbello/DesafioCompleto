using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;

namespace Desafio.Repositories
{
    /// <summary>
    /// Repositório de Tipo de Usuários herdando um repositório base e implementando a Interface
    /// </summary>
    public class TipoUsuarioRepository : BaseRepository<TipoUsuario>, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}

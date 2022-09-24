using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;

namespace Desafio_EF.Repositories
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

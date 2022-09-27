using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;

namespace Desafio.Repositories
{
    public class AcessoRepository : BaseRepository<Acesso>, IAcessoRepository
    {
        public AcessoRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}

using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;

namespace Desafio.Repositories
{
    public class NiveisDeAcessoRepository : BaseRepository<NiveisDeAcesso>, INiveisDeAcessoRepository
    {
        public NiveisDeAcessoRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}

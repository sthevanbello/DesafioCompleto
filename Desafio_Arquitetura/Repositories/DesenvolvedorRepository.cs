using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;

namespace Desafio.Repositories
{
    public class DesenvolvedorRepository : BaseRepository<Desenvolvedor>, IDesenvolvedorRepository
    {
        public DesenvolvedorRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}

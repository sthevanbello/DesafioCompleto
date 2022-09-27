using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;

namespace Desafio.Repositories
{
    public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository
    {
        public AdministradorRepository(DesafioContext desafioContext) : base(desafioContext)
        {
        }
    }
}

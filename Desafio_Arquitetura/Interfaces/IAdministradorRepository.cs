using Desafio.Models;
using System.Collections.Generic;

namespace Desafio.Interfaces
{
    public interface IAdministradorRepository : IBaseRepository<Administrador>
    {
        public ICollection<Administrador> GetAllAdministradores();
        public Administrador GetByIdAdministrador(int id);
    }
}

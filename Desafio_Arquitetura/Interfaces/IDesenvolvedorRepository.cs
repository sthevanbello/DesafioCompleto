using Desafio.Models;
using System.Collections.Generic;

namespace Desafio.Interfaces
{
    public interface IDesenvolvedorRepository : IBaseRepository<Desenvolvedor>
    {
        public ICollection<Desenvolvedor> GetAllDesenvolvedores();
        public Desenvolvedor GetByIdDesenvolvedor(int id);
    }
}

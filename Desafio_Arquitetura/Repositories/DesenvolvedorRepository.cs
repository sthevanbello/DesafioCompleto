using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Repositories
{
    public class DesenvolvedorRepository : BaseRepository<Desenvolvedor>, IDesenvolvedorRepository
    {
        private readonly DesafioContext _context;
        public DesenvolvedorRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        public ICollection<Desenvolvedor> GetAllDesenvolvedores()
        {
            return _context.Desenvolvedor
                .Include(d => d.Usuario)
                .ToList();
        }

        public Desenvolvedor GetByIdDesenvolvedor(int id)
        {
            return _context.Desenvolvedor
                .Include(d => d.Usuario)
                .FirstOrDefault(d => d.Id == id);
                
        }
    }
}

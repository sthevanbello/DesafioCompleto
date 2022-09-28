using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Repositories
{
    public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository
    {
        private readonly DesafioContext _context;

        public AdministradorRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        public ICollection<Administrador> GetAllAdministradores()
        {
            return _context.Administrador
                .Include(u => u.Usuario)
                .ToList();
        }

        public Administrador GetByIdAdministrador(int id)
        {
            return _context.Administrador
                .Include(a => a.Usuario)
                    .FirstOrDefault(a => a.Id == id);
        }
    }
}

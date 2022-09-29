using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Repositories
{
    /// <summary>
    /// Repositório de especialidades herdando um repositório base e implementando a Interface
    /// <para>Há ainda um método Get personalizado</para>
    /// </summary>
    public class EspecialidadeRepository : BaseRepository<Especialidade>, IEspecialidadeRepository
    {
        private readonly DesafioContext _context;
        public EspecialidadeRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;  
        }

        /// <summary>
        /// Exibir uma lista de especialidades com os médicos relacionados
        /// </summary>
        /// <returns>Retorna uma lista de especialidades com os médicos relacionados</returns>
        public ICollection<Especialidade> GetAllEspecialidadeComMedicos()
        {
            var especialidade = _context.Especialidade
                .Include(m => m.Medicos)
                    .ThenInclude(u => u.Usuario)
                .ToList();
            return especialidade;
        }
    }
}

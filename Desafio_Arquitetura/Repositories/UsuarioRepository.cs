using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    /// <summary>
    /// Repositório de Usuários herdando um repositório base e implementando a Interface
    /// </summary>
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DesafioContext _context;
        public UsuarioRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        /// <summary>
        /// Exibir uma lista de usuários que são médicos
        /// </summary>
        /// <returns>Retorna os Usuários que são médicos</returns>
        public ICollection<Usuario> GetUsuariosMedicos()
        {


            var medicos = _context.Usuario
                .Include(m => m.Medicos)
                    .ThenInclude(e => e.Especialidade)
                .Where(m => m.IdTipoUsuario == 2)
                .ToList();
            if (medicos != null && medicos.Count > 0)
            {
                medicos.ForEach(p => p.Senha = "Senha");
            }
            return medicos;
        }

        /// <summary>
        /// Exibir uma lista de usuários que são pacientes
        /// </summary>
        /// <returns>Retorna os Usuários que são pacientes</returns>
        public ICollection<Usuario> GetUsuariosPacientes()
        {
            var pacientes = _context.Usuario
                .Include(m => m.TipoUsuario)
                .Include(p => p.Pacientes)
                .Where(p => p.IdTipoUsuario == 1)
                .ToList();
            if (pacientes != null && pacientes.Count > 0)
            {
                pacientes.ForEach(p => p.Senha = "Senha");
            }
            return pacientes;
        }
    }
}

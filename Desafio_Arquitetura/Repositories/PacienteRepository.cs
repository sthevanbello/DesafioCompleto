using Desafio.Contexts;
using Desafio.Interfaces;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Repositories
{
    /// <summary>
    /// Repositório de Pacientes herdando um repositório base e implementando a Interface
    /// <para>Há ainda três métodos Get personalizados</para>
    /// </summary>
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        private readonly DesafioContext _context;
        public PacienteRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }
        /// <summary>
        /// Exibir Pacientes com o usuário
        /// </summary>
        /// <returns>Retorna uma lista de pacientes com o usuário preenchido</returns>
        public ICollection<Paciente> GetAllPacientes()
        {
            var pacientes = _context.Paciente
                .Include(p => p.Usuario)
                .ToList();
            return pacientes;
        }
        /// <summary>
        /// Exibir um paciente com o usuário de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Paciente</param>
        /// <returns>Retorna um paciente com um usuário preenchido</returns>
        public Paciente GetByIdPaciente(int id)
        {
            var paciente = _context.Paciente
                .Include(p => p.Usuario)
                .FirstOrDefault(p => p.Id == id);
            return paciente;
        }
        /// <summary>
        /// Exibir uma lista de Pacientes com suas respectivas consultas
        /// </summary>
        /// <returns>Retorna uma lista de pacientes com consultas e com os médicos de cada consulta</returns>
        public ICollection<Paciente> GetPacientesComConsultas()
        {
            var pacientes = _context.Paciente
                .Include(p => p.Usuario)
                    .ThenInclude(t => t.TipoUsuario)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Medico)
                        .ThenInclude(e => e.Especialidade)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Medico)
                        .ThenInclude(m => m.Usuario)
                            .ThenInclude(t => t.TipoUsuario)
                .ToList();
            return pacientes;
        }
        /// <summary>
        /// Exibir um paciente com o usuário de acordo com o Id
        /// </summary>
        /// <param name="id">Id do Paciente</param>
        /// <returns>Retorna um paciente com um usuário preenchido</returns>
        public Paciente GetByIdPacienteComConsulta(int id)
        {
            var paciente = _context.Paciente
                .Include(p => p.Usuario)
                    .ThenInclude(t => t.TipoUsuario)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Medico)
                        .ThenInclude(e => e.Especialidade)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Medico)
                        .ThenInclude(m => m.Usuario)
                            .ThenInclude(t => t.TipoUsuario)
                .FirstOrDefault(p => p.Id == id);
            return paciente;
        }
    }
}

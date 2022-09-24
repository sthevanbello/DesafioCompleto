using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    /// <summary>
    /// Repositório de Médicos herdando um repositório base e implementando a Interface
    /// <para>Há ainda três métodos Get personalizados</para>
    /// </summary>
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        private readonly DesafioContext _context;

        public MedicoRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }
        /// <summary>
        /// Exibir uma lista de médicos com os usuários preenchidos
        /// </summary>
        /// <returns>Retorna uma lista médicos com os usuários preenchidos</returns>
        public ICollection<Medico> GetAllMedicos()
        {
            var medicos = _context.Medico
                .Include(e => e.Especialidade)
                .Include(p => p.Usuario)
                .ToList();
            medicos.ForEach(m => m.Usuario.Senha = "Senha");
            return medicos;
        }
        /// <summary>
        /// Exibir o médico com o usuário preenchido de acordo com o id fornecido
        /// </summary>
        /// <returns>Retorna o médico com o usuário preenchido</returns>
        public Medico GetByIdMedico(int id)
        {
            var medico = _context.Medico
                .Include(e => e.Especialidade)
                .Include(p => p.Usuario)
                .FirstOrDefault(m => m.Id == id);
            medico.Usuario.Senha = "Senha";
            return medico;
        }

        /// <summary>
        /// Exibir uma lista de médicos com suas respectivas consultas
        /// </summary>
        /// <returns>Retorna uma lista de médicos com consultas e com os pacientes de cada consulta</returns>
        public ICollection<Medico> GetMedicosComConsultas()
        {
            var medicos = _context.Medico
                .Include(e => e.Especialidade)
                .Include(p => p.Usuario)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Paciente)
                .Include(p => p.Consultas)
                    .ThenInclude(c => c.Paciente)
                    .ThenInclude(m => m.Usuario)
                .ToList();
            medicos.ForEach(m => m.Usuario.Senha = "Senha");
            medicos.ForEach(p => p.Consultas.ForEach(p=> p.Paciente.Usuario.Senha = "Senha"));
            return medicos;
        }
    }
}

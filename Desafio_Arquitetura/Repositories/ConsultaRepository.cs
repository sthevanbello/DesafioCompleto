using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    /// <summary>
    /// Repositório de Consultas herdando um repositório base e implementando a Interface
    /// </summary>
    public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
    {
        private readonly DesafioContext _context;
        public ConsultaRepository(DesafioContext desafioContext) : base(desafioContext)
        {
            _context = desafioContext;
        }

        /// <summary>
        /// Exibir uma lista de consultas com pacientes e médicos relacionados
        /// </summary>
        /// <returns>Retorna uma lista de consultas com pacientes e médicos relacionados</returns>
        public ICollection<Consulta> GetConsultasCompletas()
        {
            var consultasCompletas = _context.Consulta

                .Include(m => m.Medico)
                    .ThenInclude(u => u.Usuario)
                        .ThenInclude(t => t.TipoUsuario)
                .Include(m => m.Medico)
                    .ThenInclude(e => e.Especialidade)
                .Include(p => p.Paciente)
                    .ThenInclude(u => u.Usuario)
                        .ThenInclude(t => t.TipoUsuario)
                .ToList();
            consultasCompletas.ForEach(m => m.Medico.Usuario.Senha = "Senha");
            consultasCompletas.ForEach(p => p.Paciente.Usuario.Senha = "Senha");
            return consultasCompletas;
        }
        /// <summary>
        /// Exibir uma consulta com o paciente e o médico relacionado de acordo com o id da consulta
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Retorna uma consulta com o paciente e o médico relacionado</returns>
        public Consulta GetConsultaCompletaById(int id)
        {
            var consultaCompleta = _context.Consulta
                .Include(m => m.Medico)
                    .ThenInclude(u => u.Usuario)
                        .ThenInclude(t => t.TipoUsuario)
                .Include(m => m.Medico)
                    .ThenInclude(e => e.Especialidade)
                .Include(p => p.Paciente)
                    .ThenInclude(u => u.Usuario)
                        .ThenInclude(t => t.TipoUsuario)
                .FirstOrDefault(c => c.Id == id);
            // Deixado o médico apenas com o nome, pois o acesso por ID é feito pelo também paciente
            // Isso foi feito para preservar dados pessoais do médico
                consultaCompleta.Medico.Usuario = new Usuario { Nome = consultaCompleta.Medico.Usuario.Nome};
                consultaCompleta.Paciente.Usuario.Senha = "Senha";
            return consultaCompleta;
        }
    }
}

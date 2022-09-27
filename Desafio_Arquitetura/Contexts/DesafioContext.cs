using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;

namespace Desafio.Contexts
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {
        }
        // Acesso ao banco de dados
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Consulta> Consulta { get; set; } // Classe de relacionamento entre Médico e Paciente
        public DbSet<NiveisDeAcesso> NiveisDeAcesso { get; set; } // Classe de níveis de acesso
        public DbSet<Desenvolvedor> Desenvolvedor { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}

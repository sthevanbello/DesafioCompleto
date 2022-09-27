using Desafio.Models;
using System.Collections.Generic;

namespace Desafio.Interfaces
{
    /// <summary>
    /// Interface de PacienteRepository implementando a interface base com os métodos básicos.
    /// <para>Há ainda um método Get personalizado</para>
    /// </summary>
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        public ICollection<Paciente> GetAllPacientes();
        public Paciente GetByIdPaciente(int id);
        public ICollection<Paciente> GetPacientesComConsultas();
        public Paciente GetByIdPacienteComConsulta(int id);
    }
}

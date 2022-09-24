using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    /// <summary>
    /// Interface de MedicoRepository implementando a interface base com os métodos básicos.
    /// <para>Há ainda um método Get personalizado</para>
    /// </summary>
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        public ICollection<Medico> GetMedicosComConsultas();
        public ICollection<Medico> GetAllMedicos();
        public Medico GetByIdMedico(int id);
    }
}

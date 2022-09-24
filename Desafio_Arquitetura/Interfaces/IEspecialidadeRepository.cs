using Desafio_EF.Models;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    /// <summary>
    /// Interface de EspecialidadeRepository implementando a interface base com os métodos básicos.
    /// <para>Há ainda um método Get personalizado</para>   
    /// </summary>
    public interface IEspecialidadeRepository : IBaseRepository<Especialidade>
    {
        public ICollection<Especialidade> GetAllEspecialidadeComMedicos();
    }
}

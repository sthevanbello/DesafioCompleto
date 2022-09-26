using Desafio.Models;
using System.Collections.Generic;

namespace Desafio.Interfaces
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

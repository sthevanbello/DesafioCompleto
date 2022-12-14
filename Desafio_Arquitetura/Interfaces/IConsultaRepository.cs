using Desafio.Models;
using System.Collections.Generic;

namespace Desafio.Interfaces
{
    /// <summary>
    /// Interface de ConsultaRepository implementando a interface base com os métodos básicos.
    /// <para>Há também dois métodos Get personalizados</para> 
    /// </summary>
    public interface IConsultaRepository : IBaseRepository<Consulta>
    {
        public ICollection<Consulta> GetConsultasCompletas();
        public Consulta GetConsultaCompletaById(int id);
    }
}

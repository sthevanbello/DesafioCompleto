using Desafio.Models;

namespace Desafio.Interfaces
{
    /// <summary>
    /// Interface de LoginRepository
    /// </summary>
    public interface IAutenticarRepository
    {
        string Logar(Autenticar login);
    }
}

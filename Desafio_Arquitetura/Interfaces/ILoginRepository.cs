using Desafio.Models;

namespace Desafio.Interfaces
{
    /// <summary>
    /// Interface de LoginRepository
    /// </summary>
    public interface ILoginRepository
    {
        string Logar(Login login);
    }
}

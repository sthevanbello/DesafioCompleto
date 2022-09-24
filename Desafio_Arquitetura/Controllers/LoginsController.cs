using Desafio_EF.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginRepository _repositoryLogin;

        public LoginsController(ILoginRepository repositoryLogin)
        {
            _repositoryLogin = repositoryLogin;
        }

        /// <summary>
        /// Insira o e-mail e a senha
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna se o login foi válido com o TOKEN ou se não foi autorizado</returns>
        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            var logar = _repositoryLogin.Logar(email, senha);
            if (logar == null)
                return Unauthorized(new {msg =  "Usuário não autorizado. Verifique se o e-mail informado e/ou a senha estão corretos"});
            return Ok(new { token = logar });
        }
    }
}

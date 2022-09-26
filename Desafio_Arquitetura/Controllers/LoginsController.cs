using Desafio.Models;
using Desafio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
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
        /// Insira o e-mail e a senha em formato Json
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Retorna se o login foi válido com o TOKEN ou se não foi autorizado</returns>
        [HttpPost]
        public IActionResult Logar(Login login)
        {
            var token = _repositoryLogin.Logar(login);
            if (token == null)
                return Unauthorized(new {msg =  "Usuário não autorizado. Verifique se o e-mail informado e/ou a senha estão corretos"});
            return Ok(token);
        }
    }
}

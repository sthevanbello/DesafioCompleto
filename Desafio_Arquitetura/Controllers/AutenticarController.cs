﻿using Desafio.Models;
using Desafio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly ILoginRepository _repositoryLogin;

        public AutenticarController(ILoginRepository repositoryLogin)
        {
            _repositoryLogin = repositoryLogin;
        }

        /// <summary>
        /// Insira o e-mail e a senha em formato Json. 
        /// </summary>
        /// <remarks>
        /// E-mails e senhas de teste:
        /// 
        /// Administrador:
        /// 
        ///     {
        ///        "email": "marge@simpsons.com",
        ///        "senha": "marge123456"
        ///     }
        ///
        /// Desenvolvedor:
        /// 
        ///     {
        ///        "email": "lisa@simpsons.com",
        ///        "senha": "lisa123456"
        ///     }
        /// Paciente:
        /// 
        ///     {
        ///        "email": "homer@simpsons.com",
        ///        "senha": "homer123456"
        ///     }
        /// Médico:
        /// 
        ///     {
        ///        "email": "apu@simpsons.com",
        ///        "senha": "apu123456"
        ///     }
        /// 
        /// </remarks>
        /// <param name="login">Dados do login fornecidos através de um Json</param>
        /// <response code="200">Login bem sucedido</response>
        /// <response code="401">Acesso negado</response>   
        [HttpPost]
        public IActionResult Logar(Login login)
        {
            var token = _repositoryLogin.Logar(login);
            if (token == null)
                return Unauthorized(new { msg = "Usuário não autorizado. Verifique se o e-mail informado e/ou a senha estão corretos" });
            return Ok(token);
        }
    }
}
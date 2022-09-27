using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Avancado, Master")]
    public class NiveisDeAcessoController : ControllerBase
    {
        private readonly INiveisDeAcessoRepository _repositoryAcesso;

        public NiveisDeAcessoController(INiveisDeAcessoRepository repositoryAcesso)
        {
            _repositoryAcesso = repositoryAcesso;
        }

        /// <summary>
        /// Exibir uma lista de níveis de acessos cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de níveis de acessos ou se houve falha</returns>
        [HttpGet]
        public IActionResult GetAllAcessos()
        {
            try
            {
                var acessos = _repositoryAcesso.GetAll();
                return Ok(acessos);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os níveis de acessos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um nível de acesso a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do nível de acesso</param>
        /// <returns>Retorna um nível de acesso ou se houve falha</returns>

        [HttpGet("{id}")]
        public IActionResult GetByIdAcesso(int id)
        {
            try
            {
                var acesso = _repositoryAcesso.GetById(id);
                if (acesso is null)
                {
                    return NotFound(new { msg = "Nível de acesso não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(acesso);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = "Falha ao exibir o nível de acesso",
                    ex.InnerException.Message
                });
            }
        }
    }
}

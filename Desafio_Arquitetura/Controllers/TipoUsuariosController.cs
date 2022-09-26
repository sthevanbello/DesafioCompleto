using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador, Desenvolvedor")]
    public class TipoUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuariosController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        /// <summary>
        /// Exibir uma lista de Tipos de usuários cadastrados no sistema
        /// </summary>
        /// <returns>Retorna uma lista de tipoUsuario ou se houve falha</returns>
        [HttpGet]
        public IActionResult GetAllTipoUsuario()
        {
            try
            {
                var tipoUsuarios = _tipoUsuarioRepository.GetAll();
                return Ok(tipoUsuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os tipos de usuários",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um tipo de usuário a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do tipo de usuário</param>
        /// <returns>Retorna um tipoUsuario ou se houve falha</returns>
        
        [HttpGet("{id}")]
        public IActionResult GetByIdTipoUsuario(int id)
        {
            try
            {
                var tipoUsuario = _tipoUsuarioRepository.GetById(id);
                if (tipoUsuario is null)
                {
                    return NotFound(new { msg = "Tipo de usuário não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(tipoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = "Falha ao exibir o tipo de usuário",
                    ex.InnerException.Message
                });
            }
        }
    }
}

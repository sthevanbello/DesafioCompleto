using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Avancado, Master")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Exibir uma lista de usuários cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna uma lista de usuários</returns>
        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os usuários",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários que são médicos cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna uma lista de usuários médicos</returns>
        [HttpGet("Medicos")]
        public IActionResult GetAllUsuariosMedicos()
        {
            try
            {
                var usuarios = _usuarioRepository.GetUsuariosMedicos();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os usuários médicos",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários que são médicos cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna uma lista de usuários pacientes</returns>
        [HttpGet("Pacientes")]
        public IActionResult GetAllUsuariosPacientes()
        {
            try
            {
                var usuarios = _usuarioRepository.GetUsuariosPacientes();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os usuários médicos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um usuário a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna um Usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdUsuario(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario is null)
                {
                    return NotFound(new { msg = "Usuário não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do usuário
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <param name="patchUsuario">informações a serem alteradas</param>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna uma mensagem dizendo se o usuário foi alterado ou se houve algum erro</returns>
        [HttpPatch("{id}")]
        public IActionResult PatchUsuario(int id, [FromBody] JsonPatchDocument patchUsuario)
        {
            try
            {
                if (patchUsuario is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var usuario = _usuarioRepository.GetById(id);
                if (usuario is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _usuarioRepository.Patch(patchUsuario, usuario);

                return Ok(new { msg = "Usuário alterado", usuario });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o usuário",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar um usuário a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do usuário</param>
        /// <param name="usuario">Dados atualizados</param>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna uma mensagem dizendo se o usuário foi alterado ou se houve algum erro</returns>
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var usuarioRetorno = _usuarioRepository.GetById(id);

                if (usuarioRetorno is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _usuarioRepository.Put(usuario);

                return Ok(new { msg = "Usuário alterado", usuario });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o usuário",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Excluir Usuário do banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do usuário a ser excluído</param>
        /// <response code="401">Acesso negado</response>
        /// <response code="403">Nível de acesso não está autorizado</response>
        /// <returns>Retorna uma mensagem informando se o usuário foi excluído ou se houve falha</returns>
        [Authorize(Roles = "Master")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                var usuarioRetorno = _usuarioRepository.GetById(id);

                if (usuarioRetorno is null)
                {
                    return NotFound(new { msg = "Usuário não encontrado. Conferir o Id informado" });
                }

                _usuarioRepository.Delete(usuarioRetorno);

                return Ok(new { msg = "Usuário excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o usuário. Verifique se há utilização como Foreign Key.",
                    ex.InnerException.Message
                });
            }
        }
    }
}

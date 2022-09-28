using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Master")]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradoresController(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        /// <summary>
        /// Inserir um administrador no banco.
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="administrador">Administrador a ser inserido</param>
        /// <returns>Retorna um Administrador inserido ou uma mensagem de falha</returns>
        [HttpPost]
        public IActionResult InsertAdministrador(Administrador administrador)
        {
            try
            {
                administrador.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(administrador.Usuario.Senha); // Criptografia da senha
                administrador.Usuario.IdTipoUsuario = 3; // Garante que o tipo de usuário será sempre 3, pois é administrador
                administrador.Usuario.IdAcesso = 3;
                var administradorInserido = _administradorRepository.Insert(administrador);
                return Ok(administradorInserido);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = "Falha ao inserir um administrador no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de administradores cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de administradores</returns>
        [HttpGet]
        public IActionResult GetAllAdministradores()
        {
            try
            {
                var administradores = _administradorRepository.GetAllAdministradores();
                return Ok(administradores);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os administradores",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um Administrador a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do Administrador</param>
        /// <returns>Retorna um Administrador</returns>
        [HttpGet("{id}")]
        public IActionResult GetByIdAdministrador(int id)
        {
            try
            {
                var administrador = _administradorRepository.GetByIdAdministrador(id);
                if (administrador == null)
                {
                    return NotFound(new { msg = "Administrador não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(administrador);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o administrador",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do administrador
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do administrador</param>
        /// <param name="patchAdministrador">informações a serem alteradas</param>
        /// <returns>Retorna uma mensagem dizendo se o administrador foi alterado ou se houve algum erro</returns>
        [HttpPatch("{id}")]
        public IActionResult PatchAdministrador(int id, [FromBody] JsonPatchDocument patchAdministrador)
        {
            try
            {
                if (patchAdministrador is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var administrador = _administradorRepository.GetById(id);
                if (administrador is null)
                {
                    return NotFound(new { msg = "Administrador não encontrado. Conferir o Id informado" });
                }

                _administradorRepository.Patch(patchAdministrador, administrador);

                return Ok(new { msg = "Administrador alterado", administrador });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o administrador",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar as informações do administrador
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do administrador</param>
        /// <param name="administrador">informações a serem alteradas</param>
        /// <returns>Retorna uma mensagem dizendo se o administrador foi alterado ou se houve algum erro</returns>
        [HttpPut("{id}")]
        public IActionResult PutAdministrador(int id, Administrador administrador)
        {
            try
            {
                if (id != administrador.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var administradorRetorno = _administradorRepository.GetById(id);

                if (administradorRetorno is null)
                {
                    return NotFound(new { msg = "Administrador não encontrado. Conferir o Id informado" });
                }
                administrador.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(administrador.Usuario.Senha);
                _administradorRepository.Put(administrador);

                return Ok(new { msg = "Administrador alterado", administrador });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o administrador",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir administrador do banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do administrador a ser excluído</param>
        /// <returns>Retorna uma mensagem informando se o administrador foi alterado ou se houve falha</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAdministrador(int id)
        {
            try
            {
                var administradorRetorno = _administradorRepository.GetById(id);

                if (administradorRetorno is null)
                {
                    return NotFound(new { msg = "Administrador não encontrado. Conferir o Id informado" });
                }

                _administradorRepository.Delete(administradorRetorno);

                return Ok(new { msg = "Administrador excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o administrador.",
                    ex.InnerException.Message
                });
            }
        }
    }
}

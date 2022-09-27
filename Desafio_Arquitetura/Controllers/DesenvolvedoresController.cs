using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Master")]
    public class DesenvolvedoresController : ControllerBase
    {
        private readonly IDesenvolvedorRepository _desenvolvedorRepository;

        public DesenvolvedoresController(IDesenvolvedorRepository desenvolvedorRepository)
        {
            _desenvolvedorRepository = desenvolvedorRepository;
        }
        /// <summary>
        /// Inserir um desenvolvedor no banco.
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="desenvolvedor">desenvolvedor a ser inserido</param>
        /// <returns>Retorna um desenvolvedor inserido ou uma mensagem de falha</returns>
        [HttpPost]
        public IActionResult Insertdesenvolvedor(Desenvolvedor desenvolvedor)
        {
            try
            {
                desenvolvedor.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(desenvolvedor.Usuario.Senha); // Criptografia da senha
                desenvolvedor.Usuario.IdTipoUsuario = 3; // Garante que o tipo de usuário será sempre 4, pois é desenvolvedor
                desenvolvedor.Usuario.IdAcesso = 3;
                var desenvolvedorInserido = _desenvolvedorRepository.Insert(desenvolvedor);
                return Ok(desenvolvedorInserido);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = "Falha ao inserir um desenvolvedor no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de desenvolvedores cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de desenvolvedores</returns>
        [HttpGet]
        public IActionResult GetAlldesenvolvedores()
        {
            try
            {
                var desenvolvedores = _desenvolvedorRepository.GetAll();
                if (desenvolvedores != null && desenvolvedores.Count > 0)
                {
                    desenvolvedores.ForEach(u => u.Usuario.Senha = "Senha");
                }
                return Ok(desenvolvedores);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os desenvolvedores",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um desenvolvedor a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do desenvolvedor</param>
        /// <returns>Retorna um desenvolvedor</returns>
        [HttpGet("{id}")]
        public IActionResult GetByIddesenvolvedor(int id)
        {
            try
            {
                var desenvolvedor = _desenvolvedorRepository.GetById(id);
                if (desenvolvedor is null)
                {
                    return NotFound(new { msg = "Desenvolvedor não foi encontrado. Verifique se o Id está correto" });
                }
                desenvolvedor.Usuario.Senha = "Senha";
                return Ok(desenvolvedor);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o desenvolvedor",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do desenvolvedor
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do desenvolvedor</param>
        /// <param name="patchdesenvolvedor">informações a serem alteradas</param>
        /// <returns>Retorna uma mensagem dizendo se o desenvolvedor foi alterado ou se houve algum erro</returns>
        [HttpPatch("{id}")]
        public IActionResult Patchdesenvolvedor(int id, [FromBody] JsonPatchDocument patchdesenvolvedor)
        {
            try
            {
                if (patchdesenvolvedor is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var desenvolvedor = _desenvolvedorRepository.GetById(id);
                if (desenvolvedor is null)
                {
                    return NotFound(new { msg = "Desenvolvedor não encontrado. Conferir o Id informado" });
                }

                _desenvolvedorRepository.Patch(patchdesenvolvedor, desenvolvedor);

                return Ok(new { msg = "Desenvolvedor alterado", desenvolvedor });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o desenvolvedor",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar as informações do desenvolvedor
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do desenvolvedor</param>
        /// <param name="desenvolvedor">informações a serem alteradas</param>
        /// <returns>Retorna uma mensagem dizendo se o desenvolvedor foi alterado ou se houve algum erro</returns>
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Desenvolvedor desenvolvedor)
        {
            try
            {
                if (id != desenvolvedor.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var desenvolvedorRetorno = _desenvolvedorRepository.GetById(id);

                if (desenvolvedorRetorno is null)
                {
                    return NotFound(new { msg = "Desenvolvedor não encontrado. Conferir o Id informado" });
                }
                desenvolvedor.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(desenvolvedor.Usuario.Senha);
                _desenvolvedorRepository.Put(desenvolvedor);

                return Ok(new { msg = "Desenvolvedor alterado", desenvolvedor });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o desenvolvedor",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir um desenvolvedor do banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do desenvolvedor a ser excluído</param>
        /// <returns>Retorna uma mensagem informando se o desenvolvedor foi alterado ou se houve falha</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteDesenvolvedor(int id)
        {
            try
            {
                var desenvolvedorRetorno = _desenvolvedorRepository.GetById(id);

                if (desenvolvedorRetorno is null)
                {
                    return NotFound(new { msg = "Desenvolvedor não encontrado. Conferir o Id informado" });
                }

                _desenvolvedorRepository.Delete(desenvolvedorRetorno);

                return Ok(new { msg = "Desenvolvedor excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o desenvolvedor.",
                    ex.InnerException.Message
                });
            }
        }
    }
}

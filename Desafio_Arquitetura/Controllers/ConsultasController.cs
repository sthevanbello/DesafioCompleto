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
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultasController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }
        /// <summary>
        /// Inserir uma consulta no banco de dados.
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Funcionário Padrão
        ///     - Administrador
        ///     - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="consulta">Consulta a ser inserida</param>
        /// <returns>Retorna a consulta inserida ou uma mensagem de erro</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpPost]
        public IActionResult InsertConsulta(Consulta consulta)
        {
            try
            {
                var consultaInserida = _consultaRepository.Insert(consulta);
                return Ok(consultaInserida);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir uma consulta no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de consultas cadastradas no banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Funcionário Padrão
        ///     - Administrador
        ///     - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de consultas ou uma mensagem de erro</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpGet]
        public IActionResult GetAllConsultas()
        {
            try
            {
                var consultas = _consultaRepository.GetConsultasCompletas();
                return Ok(consultas);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar as consultas",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma consulta a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Paciente
        ///     - Funcionário Padrão
        ///     - Administrador
        ///     - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da consulta</param>
        /// <returns>Retorna uma consulta com paciente e médico ou uma mensagem de erro</returns>
        [Authorize(Roles = "Paciente, Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpGet("{id}")]
        public IActionResult GetConsultaCompletaById(int id)
        {
            try
            {
                var consulta = _consultaRepository.GetConsultaCompletaById(id);
                if (consulta is null)
                {
                    return NotFound(new { msg = "Consulta não foi encontrada. Verifique se o Id está correto" });
                }
                return Ok(consulta);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir a consulta",
                    ex.InnerException.Message
                });
            }
        }


        /// <summary>
        /// Atualizar parte das informações da consulta
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Administrador
        ///     - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da consulta</param>
        /// <param name="patchConsulta">informações a serem alteradas</param>
        /// <returns>Retorna uma mensagem se a consulta foi alterada ou se houve algum erro</returns>
        [Authorize(Roles = "Administrador, Desenvolvedor")]
        [HttpPatch("{id}")]
        public IActionResult PatchConsulta(int id, [FromBody] JsonPatchDocument patchConsulta)
        {
            try
            {
                if (patchConsulta is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var consulta = _consultaRepository.GetById(id);
                if (consulta is null)
                {
                    return NotFound(new { msg = "Consulta não encontrada. Conferir o Id informado" });
                }

                _consultaRepository.Patch(patchConsulta, consulta);

                return Ok(new { msg = "Consulta alterada", consulta });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar a consulta",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar um consulta a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Administrador
        ///     - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da consulta</param>
        /// <param name="consulta">Dados atualizados</param>
        /// <returns>Retorna uma mensagem se a consulta foi alterada ou se houve algum erro</returns>
        [Authorize(Roles = "Administrador, Desenvolvedor")]
        [HttpPut("{id}")]
        public IActionResult PutConsulta(int id, Consulta consulta)
        {
            try
            {
                if (id != consulta.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var consultaRetorno = _consultaRepository.GetById(id);

                if (consultaRetorno is null)
                {
                    return NotFound(new { msg = "Consulta não encontrada. Conferir o Id informado" });
                }

                _consultaRepository.Put(consulta);

                return Ok(new { msg = "Consulta alterada", consulta });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o consulta",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir consulta do banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Administrador
        ///     - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da consulta a ser excluído</param>
        /// <returns>Retorna uma mensagem se a consulta foi apagada ou se houve algum erro</returns>
        [Authorize(Roles = "Administrador, Desenvolvedor")]
        [HttpDelete("{id}")]
        public IActionResult DeleteConsulta(int id)
        {
            try
            {
                var consultaRetorno = _consultaRepository.GetById(id);

                if (consultaRetorno is null)
                {
                    return NotFound(new { msg = "Consulta não encontrada. Conferir o Id informado" });
                }

                _consultaRepository.Delete(consultaRetorno);

                return Ok(new { msg = "Consulta excluída com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir a consulta",
                    ex.InnerException.Message
                });
            }
        }

    }
}

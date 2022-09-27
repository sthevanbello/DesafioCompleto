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
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicosController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        /// <summary>
        /// Inserir um Médico no banco com a sua especialidade e com os dados de usuário, caso não tenha sido inserido no banco anteriormente
        /// </summary>
        /// /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// Especialidade:
        /// 
        ///     1 - Clínico Geral
        ///     2 - Cardiologia
        ///     3 - Ortopedia
        ///     4 - Otorrinolaringologista
        ///     5 - Gastroenterologista
        ///     6 - Endocrinologia
        /// 
        /// </remarks>
        /// <param name="medico">Médico a ser inserido no banco de dados</param>
        /// <returns>Retorna o médico inserido ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpPost]
        public IActionResult InsertMedico(Medico medico)
        {
            try
            {
                medico.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(medico.Usuario.Senha); // Criptografia da senha
                medico.Usuario.IdTipoUsuario = 2; // Garante que o tipo de usuário médico será sempre 2
                medico.Usuario.IdAcesso = 2;
                var medicoInserido = _medicoRepository.Insert(medico);
                return Ok(medicoInserido);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir um Médico no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de Médico cadastrados no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Intermediario - Usuário interno (Médico)
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de médicos ou uma mensagem de erro</returns>
        [Authorize(Roles = "Intermediario, Avancado, Master")]
        [HttpGet]
        public IActionResult GetAllMedicos()
        {
            try
            {
                var Medicos = _medicoRepository.GetAllMedicos();
                return Ok(Medicos);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os Médicos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma lista de médicos e suas consultas cadastradas no sistema
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Intermediario - Usuário interno (Médico)
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de médicos com as consultas ou uma mensagem de erro</returns>
        [Authorize(Roles = "Intermediario, Avancado, Master")]
        [HttpGet("Consultas")]
        public IActionResult GetAllMedicosComConsulta()
        {
            try
            {
                var pacientes = _medicoRepository.GetMedicosComConsultas();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os médicos",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um Médico a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Intermediario - Usuário interno (Médico)
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do Medico</param>
        /// <returns>Retorna um médico ou uma mensagem de erro</returns>
        [Authorize(Roles = "Intermediario, Avancado, Master")]
        [HttpGet("{id}")]
        public IActionResult GetByIdMedico(int id)
        {
            try
            {
                var medico = _medicoRepository.GetByIdMedico(id);
                if (medico is null)
                {
                    return NotFound(new { msg = "Médico não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(medico);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o Médico",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do Médico
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id do Médico</param>
        /// <param name="patchMedico">informações a serem alteradas</param>
        /// <returns>Retorna se o médico foi alterado ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpPatch("{id}")]
        public IActionResult PatchMedico(int id, [FromBody] JsonPatchDocument patchMedico)
        {
            try
            {
                if (patchMedico.Operations[0].path == "senha")
                {
                    throw new InvalidOperationException("Só poderá alterar a senha utilizando o método PUT, pois a senha é de Usuário e não de Médico");
                }
                if (patchMedico is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var medico = _medicoRepository.GetById(id);
                if (medico is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Patch(patchMedico, medico);

                return Ok(new { msg = "Médico alterado", medico });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o Médico",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar um Médico a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da Medico</param>
        /// <param name="medico">Dados atualizados</param>
        /// <returns>Retorna se o médico foi alterado ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpPut("{id}")]
        public IActionResult PutMedico(int id, Medico medico)
        {
            try
            {
                if (id != medico.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var medicoRetorno = _medicoRepository.GetById(id);

                if (medicoRetorno is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }
                medico.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(medico.Usuario.Senha); // Criptografia da senha
                _medicoRepository.Put(medico);

                return Ok(new { msg = "Médico alterado", medico });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o Médico",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir Médico do banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da Médico a ser excluído</param>
        /// <returns>Retorna se o médico foi apagado ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(int id)
        {
            try
            {
                var medicoRetorno = _medicoRepository.GetById(id);

                if (medicoRetorno is null)
                {
                    return NotFound(new { msg = "Médico não encontrado. Conferir o Id informado" });
                }

                _medicoRepository.Delete(medicoRetorno);

                return Ok(new { msg = "Médico excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o Médico. Verifique se há utilização como Foreign Key de alguma consulta",
                    ex.InnerException.Message
                });
            }
        }
    }
}

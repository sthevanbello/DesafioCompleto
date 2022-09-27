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
    public class EspecialidadesController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadesController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

        /// <summary>
        /// Inserir uma especialidade no banco de dados.
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="especialidade">Especialidade a ser inserida</param>
        /// <returns>Retorna a especialidade inserida ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpPost]
        public IActionResult InsertEspecialidade(Especialidade especialidade)
        {
            try
            {
                var especialidadeInserida = _especialidadeRepository.Insert(especialidade);
                return Ok(especialidadeInserida);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao inserir uma especialidade no banco",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma lista de especialidades cadastradas no banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Inicial       - Usuário externo (Pacientes)
        ///     - Intermediário - Usuário interno (Médico)
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de especialidades ou uma mensagem de erro</returns>
        [Authorize(Roles = "Inicial, Intermediario, Avancado, Master")]
        [HttpGet]
        public IActionResult GetAllEspecialidades()
        {
            try
            {
                var especialidades = _especialidadeRepository.GetAll();
                return Ok(especialidades);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar as especialidades",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma lista de especialidades cadastradas no banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Inicial       - Usuário externo (Pacientes)
        ///     - Intermediário - Usuário interno (Médico)
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <returns>Retorna uma lista de especialidades com os médicos ou uma mensagem de erro</returns>
        [Authorize(Roles = "Inicial, Intermediario, Avancado, Master")]
        [HttpGet("Medicos")]
        public IActionResult GetAllEspecialidadeComMedicos()
        {
            try
            {
                var especialidades = _especialidadeRepository.GetAllEspecialidadeComMedicos();
                return Ok(especialidades);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar as especialidades. Pode haver um(a) médico(a) associado(a) à especialidade",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma especialidade a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Inicial       - Usuário externo (Pacientes)
        ///     - Intermediário - Usuário interno (Médico)
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da especialidade</param>
        /// <returns>Retorna uma especialidade ou uma mensagem de erro</returns>
        [Authorize(Roles = "Inicial, Intermediario, Avancado, Master")]
        [HttpGet("{id}")]
        public IActionResult GetEspecialidadeById(int id)
        {
            try
            {
                var especialidade = _especialidadeRepository.GetById(id);
                if (especialidade is null)
                {
                    return NotFound(new { msg = "Especialidade não foi encontrada. Verifique se o Id está correto" });
                }
                return Ok(especialidade);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir a especialidade",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações da especialidade
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da especialidade</param>
        /// <param name="patchEspecialidade">informações a serem alteradas</param>
        /// <returns>Retorna se a especialidade foi alterada ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpPatch("{id}")]
        public IActionResult PatchEspecialidade(int id, [FromBody] JsonPatchDocument patchEspecialidade)
        {
            try
            {
                if (patchEspecialidade is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }

                var especialidade = _especialidadeRepository.GetById(id);
                if (especialidade is null)
                {
                    return NotFound(new { msg = "Especialidade não encontrada. Conferir o Id informado" });
                }

                _especialidadeRepository.Patch(patchEspecialidade, especialidade);

                return Ok(new { msg = "Especialidade alterada", especialidade });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar a especialidade",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Alterar uma especialidade a partir do Id fornecido
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da especialidade</param>
        /// <param name="especialidade">Dados atualizados</param>
        /// <returns>Retorna se a especialidade foi alterada ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpPut("{id}")]
        public IActionResult PutEspecialidade(int id, Especialidade especialidade)
        {
            try
            {
                if (id != especialidade.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var especialidadeRetorno = _especialidadeRepository.GetById(id);

                if (especialidadeRetorno is null)
                {
                    return NotFound(new { msg = "Especialidade não encontrada. Conferir o Id informado" });
                }

                _especialidadeRepository.Put(especialidade);

                return Ok(new { msg = "Especialidade alterada", especialidade });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar a especialidade",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir especialidade do banco de dados
        /// </summary>
        /// <remarks>
        /// 
        /// Acesso permitido:
        /// 
        ///     - Avançado      - Administrador
        ///     - Master        - Desenvolvedor
        /// 
        /// </remarks>
        /// <param name="id">Id da especialidade a ser excluído</param>
        /// <returns>Retorna se a especialidade foi apagada ou uma mensagem de erro</returns>
        [Authorize(Roles = "Avancado, Master")]
        [HttpDelete("{id}")]
        public IActionResult DeleteEspecialidade(int id)
        {
            try
            {
                var especialidadeRetorno = _especialidadeRepository.GetById(id);

                if (especialidadeRetorno is null)
                {
                    return NotFound(new { msg = "Especialidade não encontrada. Conferir o Id informado" });
                }

                _especialidadeRepository.Delete(especialidadeRetorno);

                return Ok(new { msg = "Especialidade excluída com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir a especialidade. Verifique se há utilização como Foreign Key de algum(a) médico(a)",
                    ex.InnerException.Message
                });
            }
        }
    }
}

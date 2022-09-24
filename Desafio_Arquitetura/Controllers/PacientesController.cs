﻿using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Desafio_EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        /// <summary>
        /// Inserir um paciente no banco.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>Retorna um paciente inserido ou se houve falha</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpPost]
        public IActionResult InsertPaciente(Paciente paciente)
        {
            try
            {
                paciente.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Usuario.Senha);
                paciente.Usuario.IdTipoUsuario = 1; // Garante que o tipo de usuário será sempre 1, pois é paciente
                var pacienteInserido = _pacienteRepository.Insert(paciente);
                return Ok(pacienteInserido);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    msg = "Falha ao inserir um paciente no banco",
                    ex.InnerException.Message
                });
            }
        }
        /// <summary>
        /// Exibir uma lista de usuários cadastrados no sistema
        /// </summary>
        /// <returns>Retorna um paciente ou se houve falha</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpGet]
        public IActionResult GetAllPacientes()
        {
            try
            {
                var pacientes = _pacienteRepository.GetAllPacientes();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os pacientes",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir uma lista de pacientes e suas consultas cadastradas no sistema
        /// </summary>
        /// <returns>Retorna uma lista de  pacientes comconsultas ou se houve falha</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpGet("Consultas")]
        public IActionResult GetAllPacientesComConsulta()
        {
            try
            {
                var pacientes = _pacienteRepository.GetPacientesComSonsultas();
                return Ok(pacientes);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao listar os pacientes",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Exibir um paciente a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Retorna um paciente ou se houve falha</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpGet("{id}")]
        public IActionResult GetByIdPaciente(int id)
        {
            try
            {
                var paciente = _pacienteRepository.GetByIdPaciente(id);
                if (paciente is null)
                {
                    return NotFound(new { msg = "Paciente não foi encontrado. Verifique se o Id está correto" });
                }
                return Ok(paciente);
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao exibir o paciente",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Atualizar parte das informações do paciente
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <param name="patchPaciente">informações a serem alteradas</param>
        /// <returns>Retorna uma mensagem informando se o paciente teve seu dado alterado ou se houve falha</returns>
        //[Authorize]
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpPatch("{id}")]
        public IActionResult PatchPaciente(int id, [FromBody] JsonPatchDocument patchPaciente)
        {
            try
            {
                if (patchPaciente.Operations[0].path == "senha")
                {
                    throw new InvalidOperationException("Só poderá alterar a senha utilizando o método PUT, pois a senha é de Usuário e não de Paciente");
                }
                if (patchPaciente is null)
                {
                    return BadRequest(new { msg = "Insira os dados novos" });
                }
                var paciente = _pacienteRepository.GetByIdPaciente(id);
                if (paciente is null)
                {
                    return NotFound(new { msg = "Paciente não encontrado. Conferir o Id informado" });
                }
                
                _pacienteRepository.Patch(patchPaciente, paciente);

                return Ok(new { msg = "Paciente alterado", paciente });
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o usuário",
                    ex.Message
                });
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
        /// Alterar um paciente a partir do Id fornecido
        /// </summary>
        /// <param name="id">Id da paciente</param>
        /// <param name="paciente">Dados atualizados</param>
        /// <returns>Retorna uma mensagem informando se o paciente foi alterado ou se houve falha</returns>
        [Authorize(Roles = "Funcionario_Padrao, Administrador, Desenvolvedor")]
        [HttpPut("{id}")]
        public IActionResult PutPaciente(int id, Paciente paciente)
        {
            try
            {
                if (id != paciente.Id)
                {
                    return BadRequest(new { msg = "Os ids não são correspondentes" });
                }
                var pacienteRetorno = _pacienteRepository.GetById(id);

                if (pacienteRetorno is null)
                {
                    return NotFound(new { msg = "Paciente não encontrado. Conferir o Id informado" });
                }
                paciente.Usuario.Senha = BCrypt.Net.BCrypt.HashPassword(paciente.Usuario.Senha);
                _pacienteRepository.Put(paciente);

                return Ok(new { msg = "Paciente alterado", paciente });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao alterar o paciente",
                    ex.InnerException.Message
                });
            }
        }

        /// <summary>
        /// Excluir paciente do banco de dados
        /// </summary>
        /// <param name="id">Id da paciente a ser excluído</param>
        /// <returns>Retorna uma mensagem informando se o paciente foi alterado ou se houve falha</returns>
        [Authorize(Roles = "Administrador, Desenvolvedor")]
        [HttpDelete("{id}")]
        public IActionResult DeletePaciente(int id)
        {
            try
            {
                var pacienteRetorno = _pacienteRepository.GetById(id);

                if (pacienteRetorno is null)
                {
                    return NotFound(new { msg = "Paciente não encontrado. Conferir o Id informado" });
                }

                _pacienteRepository.Delete(pacienteRetorno);

                return Ok(new { msg = "Paciente excluído com sucesso" });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    msg = "Falha ao excluir o paciente. Verifique se há utilização como Foreign Key de alguma consulta.",
                    ex.InnerException.Message
                });
            }
        }
    }
}
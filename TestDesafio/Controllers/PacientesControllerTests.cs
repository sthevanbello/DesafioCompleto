using Desafio.Contexts;
using Desafio.Controllers;
using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Controllers
{
    public class PacientesControllerTests
    {
        // Preparação - Criar um repositório Fake e ustilizá-lo no controller
        private readonly Mock<IPacienteRepository> _mockRepo;
        private readonly PacientesController _controller;

        public PacientesControllerTests()
        {
            _mockRepo = new Mock<IPacienteRepository>();
            _controller = new PacientesController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkPacientes()
        {
            // Execução
            var result = _controller.GetAllPacientes();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessPacientes()
        {
            // Execução - Act
            var result = _controller.GetAllPacientes();
            var OkObjectresult = result as OkObjectResult;
            // Retorno
            Assert.Equal(200, OkObjectresult.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestInsertPaciente()
        {
            var result = _controller.InsertPaciente(new()
            {
                Ativo = true,
                Carteirinha = "123456789",
                DataNascimento = DateTime.Now,
                IdUsuario = 100,
                Usuario = new Usuario
                {
                    Nome = "Teste",
                    IdAcesso = 1,
                    Email = "teste@testeautomatizado.com",
                    Senha = "teste123456",
                    IdTipoUsuario = 1,
                }
            });
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: NotNull
        /// </summary>
        [Fact]
        public void TestActionResultNotNullPacientes()
        {
            // Execução - Act
            var result = _controller.GetAllPacientes();
            // Retorno
            Assert.NotNull(result);
        }
    }
}

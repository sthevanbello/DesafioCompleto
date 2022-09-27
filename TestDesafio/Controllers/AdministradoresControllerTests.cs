using Desafio.Controllers;
using Desafio.Interfaces;
using Desafio.Models;
using Desafio.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Controllers
{
    public class AdministradoresControllerTests
    {
        // Preparação - Criar um repositório Fake e ustilizá-lo no controller
        private readonly Mock<IAdministradorRepository> _mockRepo;
        private readonly AdministradoresController _controller;

        public AdministradoresControllerTests()
        {
            _mockRepo = new Mock<IAdministradorRepository>();
            _controller = new AdministradoresController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkConsultas()
        {

            // Execução
            var result = _controller.GetAllAdministradores();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessConsultas()
        {
            // Execução - Act
            var actionResult = _controller.GetAllAdministradores();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestInsertConsulta()
        {
            var result = _controller.InsertAdministrador(new()
            {
                CPF = "12345678910",
                IdUsuario = 100,
                Usuario = new Usuario
                {
                    Nome = "Teste",
                    Email = "teste@testeautomatizado.com",
                    Senha = "teste123456",
                    IdTipoUsuario = 1,
                    IdAcesso = 1
                }
            });
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: NotNull
        /// </summary>
        [Fact]
        public void TestActionResultNotNullConsultas()
        {
            // Execução - Act
            var actionResult = _controller.GetAllAdministradores();
            // Retorno
            Assert.NotNull(actionResult);
        }
    }
}

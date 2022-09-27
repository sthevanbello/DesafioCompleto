using Desafio.Controllers;
using Desafio.Interfaces;
using Desafio.Models;
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
    public class DesenvolvedoresControllerTests
    {
        // Preparação - Criar um repositório Fake e ustilizá-lo no controller
        private readonly Mock<IDesenvolvedorRepository> _mockRepo;
        private readonly DesenvolvedoresController _controller;

        public DesenvolvedoresControllerTests()
        {
            _mockRepo = new Mock<IDesenvolvedorRepository>();
            _controller = new DesenvolvedoresController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkConsultas()
        {

            // Execução
            var result = _controller.GetAlldesenvolvedores();
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
            var actionResult = _controller.GetAlldesenvolvedores();
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
            var result = _controller.Insertdesenvolvedor(new()
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
            var actionResult = _controller.GetAlldesenvolvedores();
            // Retorno
            Assert.NotNull(actionResult);
        }
    }
}

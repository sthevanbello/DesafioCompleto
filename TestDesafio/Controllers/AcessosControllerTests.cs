using Desafio.Controllers;
using Desafio.Interfaces;
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
    public class AcessosControllerTests
    {
        // Preparação - Criar um repositório Fake e ustilizá-lo no controller
        private readonly Mock<IAcessoRepository> _mockRepo;
        private readonly AcessosController _controller;

        public AcessosControllerTests()
        {
            _mockRepo = new Mock<IAcessoRepository>();
            _controller = new AcessosController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkAcessos()
        {
            // Execução
            var result = _controller.GetAllAcessos();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessAcessos()
        {
            // Execução - Act
            var result = _controller.GetAllAcessos();
            var OkObjectresult = result as OkObjectResult;
            // Retorno
            Assert.Equal(200, OkObjectresult.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: NotNull
        /// </summary>
        [Fact]
        public void TestActionResultNotNullAcessos()
        {
            // Execução - Act
            var result = _controller.GetAllAcessos();
            // Retorno
            Assert.NotNull(result);
        }
    }
}

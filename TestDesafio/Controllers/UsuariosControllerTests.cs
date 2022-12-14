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
    public class UsuariosControllerTests
    {
        // Preparação - Criar um repositório Fake e utilizá-lo no controller
        private readonly Mock<IUsuarioRepository> _mockRepo;
        private readonly UsuariosController _controller;

        public UsuariosControllerTests()
        {
            _mockRepo = new Mock<IUsuarioRepository>();
            _controller = new UsuariosController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkUsuarios()
        {

            // Execução
            var result = _controller.GetAllUsuarios();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessUsuarios()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuarios();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessUsuariosMedicos()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuariosMedicos();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessUsuariosPacientes()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuariosPacientes();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: NotNull
        /// </summary>
        [Fact]
        public void TestActionResultNotNullUsuarios()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuarios();
            // Retorno
            Assert.NotNull(actionResult);
        }
    }
}

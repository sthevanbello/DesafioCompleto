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
    /// <summary>
    /// Classe de testes do ConsultasController
    /// </summary>
    public class ConsultasControllerTests
    {
        // Preparação - Criar um repositório Fake e ustilizá-lo no controller
        private readonly Mock<IConsultaRepository> _mockRepo;
        private readonly ConsultasController _controller;

        public ConsultasControllerTests()
        {
            _mockRepo = new Mock<IConsultaRepository>();
            _controller = new ConsultasController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkConsultas()
        {

            // Execução
            var result = _controller.GetAllConsultas();
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
            var actionResult = _controller.GetAllConsultas();
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
            var result = _controller.InsertConsulta(new()
            {
                DataHora = DateTime.Now,
                IdMedico = 1,
                IdPaciente = 1,
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
            var actionResult = _controller.GetAllConsultas();
            // Retorno
            Assert.NotNull(actionResult);
        }
    }
}

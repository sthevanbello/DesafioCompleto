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
    public class ConsultasControllerTests
    {
        private readonly Mock<IConsultaRepository> _mockRepo;
        private readonly ConsultasController _controller;

        public ConsultasControllerTests()
        {
            _mockRepo = new Mock<IConsultaRepository>();
            _controller = new ConsultasController(_mockRepo.Object);
        }

        [Fact]
        public void TestActionResultReturnOkConsultas()
        {

            // Execução
            var result = _controller.GetAllConsultas();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestStatusCodeSuccessConsultas()
        {
            // Execução - Act
            var actionResult = _controller.GetAllConsultas();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
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

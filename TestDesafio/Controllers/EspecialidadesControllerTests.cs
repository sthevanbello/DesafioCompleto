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
    public class EspecialidadesControllerTests
    {
        private readonly Mock<IEspecialidadeRepository> _mockRepo;
        private readonly EspecialidadesController _controller;

        public EspecialidadesControllerTests()
        {
            _mockRepo = new Mock<IEspecialidadeRepository>();
            _controller = new EspecialidadesController(_mockRepo.Object);
        }
        [Fact]
        public void TestActionResultReturnOkEspecialidades()
        {

            // Execução
            var result = _controller.GetAllEspecialidades();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestActionResultReturnOkEspecialidadesComMedicos()
        {

            // Execução
            var result = _controller.GetAllEspecialidadeComMedicos();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestStatusCodeSuccessEspecialidades()
        {
            // Execução - Act
            var actionResult = _controller.GetAllEspecialidades();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void TestInsertEspecialidade()
        {
            var result = _controller.InsertEspecialidade(new()
            {
                Categoria = "Especialidade teste"
            });
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestActionResultNotNullEspecialidades()
        {
            // Execução - Act
            var actionResult = _controller.GetAllEspecialidades();
            // Retorno
            Assert.NotNull(actionResult);
        }
    }
}

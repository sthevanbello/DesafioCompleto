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
        // Preparação - Criar um repositório Fake e ustilizá-lo no controller
        private readonly Mock<IEspecialidadeRepository> _mockRepo;
        private readonly EspecialidadesController _controller;

        public EspecialidadesControllerTests()
        {
            _mockRepo = new Mock<IEspecialidadeRepository>();
            _controller = new EspecialidadesController(_mockRepo.Object);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkEspecialidades()
        {

            // Execução
            var result = _controller.GetAllEspecialidades();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestActionResultReturnOkEspecialidadesComMedicos()
        {

            // Execução
            var result = _controller.GetAllEspecialidadeComMedicos();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: Status Code 200
        /// </summary>
        [Fact]
        public void TestStatusCodeSuccessEspecialidades()
        {
            // Execução - Act
            var actionResult = _controller.GetAllEspecialidades();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: OkObjectResult
        /// </summary>
        [Fact]
        public void TestInsertEspecialidade()
        {
            var result = _controller.InsertEspecialidade(new()
            {
                Categoria = "Especialidade teste"
            });
            Assert.IsType<OkObjectResult>(result);
        }
        /// <summary>
        /// Testar o retorno do método. Retorno esperado: NotNull
        /// </summary>
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

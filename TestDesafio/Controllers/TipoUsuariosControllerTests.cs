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
    public class TipoUsuariosControllerTests
    {
        private readonly Mock<ITipoUsuarioRepository> _mockRepo;
        private readonly TipoUsuariosController _controller;

        public TipoUsuariosControllerTests()
        {
            _mockRepo = new Mock<ITipoUsuarioRepository>();
            _controller = new TipoUsuariosController(_mockRepo.Object);
        }

        [Fact]
        public void TestActionResultReturnOkTipoUsuario()
        {
            // Execução
            var result = _controller.GetAllTipoUsuario();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestStatusCodeSuccessTipoUsuario()
        {
            // Execução - Act
            var result = _controller.GetAllTipoUsuario();
            var OkObjectresult = result as OkObjectResult;
            // Retorno
            Assert.Equal(200, OkObjectresult.StatusCode);
        }
        [Fact]
        public void TestActionResultNotNullTipoUsuario()
        {
            // Execução - Act
            var result = _controller.GetAllTipoUsuario();
            // Retorno
            Assert.NotNull(result);
        }
    }
}

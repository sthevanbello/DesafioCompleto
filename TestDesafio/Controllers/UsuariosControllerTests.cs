using Desafio_EF.Controllers;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
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
        // Preparação
        private readonly Mock<IUsuarioRepository> _mockRepo;
        private readonly UsuariosController _controller;

        public UsuariosControllerTests()
        {
            _mockRepo = new Mock<IUsuarioRepository>();
            _controller = new UsuariosController(_mockRepo.Object);
        }

        
        [Fact]
        public void TestStatusCodeSuccessUsuariosMedicos()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuariosMedicos();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void TestStatusCodeSuccessUsuariosPacientes()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuariosPacientes();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }
        [Fact]
        public void TestStatusCodeSuccessUsuarios()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuarios();
            var result = actionResult as OkObjectResult;
            // Retorno
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void TestActionResultNotNull()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuarios();
            // Retorno
            Assert.NotNull(actionResult);
        }
        [Fact]
        public void TestActionResultReturnOk()
        {

            // Execução
            var result = _controller.GetAllUsuarios();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestGetAllUsuario()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuarios();
            var okObjectResult = actionResult as OkObjectResult;
            okObjectResult.Value = new List<Usuario>();
            // Retorno
            Assert.IsAssignableFrom<List<Usuario>>(okObjectResult.Value);
        }


        [Fact]
        public void TestGetAllUsuarioPaciente()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuariosPacientes();
            var okObjectResult = actionResult as OkObjectResult;
            okObjectResult.Value = new List<Usuario>();
            // Retorno
            Assert.IsAssignableFrom<List<Usuario>>(okObjectResult.Value);
        }
        [Fact]
        public void TestGetAllUsuarioMedico()
        {
            // Execução - Act
            var actionResult = _controller.GetAllUsuariosMedicos();
            var okObjectResult = actionResult as OkObjectResult;
            okObjectResult.Value = new List<Usuario>();
            // Retorno
            Assert.IsAssignableFrom<List<Usuario>>(okObjectResult.Value);
        }
    }
}

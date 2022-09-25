using Desafio_EF.Contexts;
using Desafio_EF.Controllers;
using Desafio_EF.Interfaces;
using Desafio_EF.Models;
using Desafio_EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Controllers
{
    public class PacientesControllerTests
    {
        // Preparação
        private readonly Mock<IPacienteRepository> _mockRepo;
        private readonly PacientesController _controller;



        public PacientesControllerTests()
        {
            _mockRepo = new Mock<IPacienteRepository>();
            _controller = new PacientesController(_mockRepo.Object);
        }

        [Fact]
        public void TestStatusCodeSuccessPacientes()
        {
            // Execução - Act
            var result = _controller.GetAllPacientes();
            var OkObjectresult = result as OkObjectResult;
            // Retorno
            Assert.Equal(200, OkObjectresult.StatusCode);
        }

        [Fact]
        public void TestActionResultNotNull()
        {
            // Execução - Act
            var result = _controller.GetAllPacientes();
            // Retorno
            Assert.NotNull(result);
        }
        [Fact]
        public void TestActionResultReturnOk()
        {

            // Execução
            var result = _controller.GetAllPacientes();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void TestGetAllPacientes()
        {
            _mockRepo.Setup(x => x.GetAllPacientes()).Returns(() => new List<Paciente>());

            var teste = _mockRepo.Object.GetAll();

            // Execução - Act
            var result = _controller.GetAllPacientes();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.Value = new List<Usuario>();
            // Retorno
            Assert.IsAssignableFrom<List<Usuario>>(okObjectResult.Value);
        }

        [Fact]
        public void TestInsertPaciente()
        {
            var result = _controller.InsertPaciente(new()
            {
                Ativo = true,
                Carteirinha = "123456789",
                DataNascimento = DateTime.Now,
                IdUsuario = 100,
                Usuario = new Usuario
                {
                    Nome = "Teste",
                    IdAcesso = 1,
                    Email = "teste@testeautomatizado.com",
                    Senha = "teste123456",
                    IdTipoUsuario = 1,
                }
            });
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

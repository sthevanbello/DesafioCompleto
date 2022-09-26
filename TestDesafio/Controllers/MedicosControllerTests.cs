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
    public class MedicosControllerTests
    {
        // Preparação
        private readonly Mock<IMedicoRepository> _mockRepo;
        private readonly MedicosController _controller;

        public MedicosControllerTests()
        {
            _mockRepo = new Mock<IMedicoRepository>();
            _controller = new MedicosController(_mockRepo.Object);
        }

        [Fact]
        public void TestActionResultReturnOk()
        {

            // Execução
            var result = _controller.GetAllMedicos();
            // Retorno
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void TestStatusCodeSuccessMedicos()
        {
            // Execução - Act
            var result = _controller.GetAllMedicos();
            var OkObjectresult = result as OkObjectResult;
            // Retorno
            Assert.Equal(200, OkObjectresult.StatusCode);
        }
        [Fact]
        public void TestInsertMedicos()
        {
            var result = _controller.InsertMedico(new()
            {
                CRM = "123456789",
                IdUsuario = 100,
                IdEspecialidade = 1,
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
        [Fact]
        public void TestActionResultNotNull()
        {
            // Execução - Act
            var result = _controller.GetAllMedicos();
            // Retorno
            Assert.NotNull(result);
        }
    }
}

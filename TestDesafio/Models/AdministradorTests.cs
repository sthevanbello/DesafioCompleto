using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class AdministradorTests
    {
        /// <summary>
        /// Testar se o objeto criado é NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarAdministradorNotNull()
        {
            //Preparação
            Administrador admin;

            // Execução
            admin = new Administrador();

            // Retorno esperado
            Assert.NotNull(admin);
        }

        [Fact]
        public void DeveRetornarSeOCPFEhValido()
        {
            //Preparação
            Administrador admin;

            // Execução
            admin = new Administrador
            {
                Id = 5,
                CPF = "12345678910",
                IdUsuario = 3,
                Usuario = new Usuario
                {
                    Nome = "Teste",
                    IdAcesso = 1,
                    Email = "teste@testeautomatizado.com",
                    Senha = "teste123456",
                    IdTipoUsuario = 1,
                }
            };

            // Retorno esperado
            Assert.NotNull(admin.Usuario);

        }
    }
}

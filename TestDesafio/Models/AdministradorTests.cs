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
        /// Testar se o objeto instanciado retorna NotNull
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
        /// <summary>
        /// Testar se o CPF possui 11 dígitos
        /// </summary>
        [Fact]
        public void DeveRetornarSeOCPFPossuiOTamanhoCorreto()
        {
            //Preparação
            Administrador admin;

            // Execução
            admin = new Administrador
            {
                Id = 5,
                CPF = "12345678910",
                IdUsuario = 3,
                Usuario = new Usuario()
            };

            // Retorno esperado
            Assert.Equal(11, admin.CPF.Length);

        }
    }
}

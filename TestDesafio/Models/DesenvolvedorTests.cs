using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public  class DesenvolvedorTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarDesenvolvedorNotNull()
        {
            //Preparação
            Desenvolvedor dev;

            // Execução
            dev = new Desenvolvedor();

            // Retorno esperado
            Assert.NotNull(dev);
        }
        /// <summary>
        /// Testar se o CPF possui 11 dígitos
        /// </summary>
        [Fact]
        public void DeveRetornarSeOCPFPossuiOTamanhoCorreto()
        {
            //Preparação
            Desenvolvedor dev;

            // Execução
            dev = new Desenvolvedor
            {
                Id = 5,
                CPF = "12345678910",
                IdUsuario = 3,
                Usuario = new Usuario()
            };

            // Retorno esperado
            Assert.Equal(11, dev.CPF.Length);

        }
    }
}

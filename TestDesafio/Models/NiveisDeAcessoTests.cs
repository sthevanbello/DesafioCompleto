using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class NiveisDeAcessoTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarNiveisDeAcessoNotNull()
        {
            //Preparação
            NiveisDeAcesso nivel;

            // Execução
            nivel = new NiveisDeAcesso();

            // Retorno esperado
            Assert.NotNull(nivel);
        }
    }
}

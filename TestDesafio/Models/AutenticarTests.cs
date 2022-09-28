using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class AutenticarTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarAutenticarNotNull()
        {
            //Preparação
            Autenticar autenticar;

            // Execução
            autenticar = new Autenticar();

            // Retorno esperado
            Assert.NotNull(autenticar);
        }
    }
}

using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class EspecialidadeTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarEspecialidadeNotNull()
        {
            //Preparação
            Especialidade especialidade;

            // Execução
            especialidade = new Especialidade();

            // Retorno esperado
            Assert.NotNull(especialidade);
        }
    }
}

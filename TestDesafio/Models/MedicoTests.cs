using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class MedicoTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarMedicoNotNull()
        {
            //Preparação
            Medico medico;

            // Execução
            medico = new Medico();

            // Retorno esperado
            Assert.NotNull(medico);
        }
    }
}

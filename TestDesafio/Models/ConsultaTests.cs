using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class ConsultaTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void DeveRetornarConsultaNotNull()
        {
            //Preparação
            Consulta consulta;

            // Execução
            consulta = new Consulta();

            // Retorno esperado
            Assert.NotNull(consulta);
        }
    }
}

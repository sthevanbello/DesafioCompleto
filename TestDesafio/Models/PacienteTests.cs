using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class PacienteTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void TestarDeveRetornarTipoUsuarioNotNull()
        {
            //Preparação
            Paciente paciente;

            // Execução
            paciente = new Paciente();

            // Retorno esperado
            Assert.NotNull(paciente);
        }
    }
}

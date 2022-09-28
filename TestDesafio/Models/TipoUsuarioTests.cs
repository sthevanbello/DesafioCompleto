using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestDesafio.Models
{
    public class TipoUsuarioTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void TestarDeveRetornarTipoUsuarioNotNull()
        {
            //Preparação
            TipoUsuario tipoUsuario;

            // Execução
            tipoUsuario = new TipoUsuario();

            // Retorno esperado
            Assert.NotNull(tipoUsuario);
        }
    }
}

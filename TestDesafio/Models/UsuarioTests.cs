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
    public class UsuarioTests
    {
        /// <summary>
        /// Testar se o objeto instanciado retorna NotNull
        /// </summary>
        [Fact]
        public void TestarDeveRetornarUsuarioNotNull()
        {
            //Preparação
            Usuario usuario;

            // Execução
            usuario = new Usuario();

            // Retorno esperado
            Assert.NotNull(usuario);
        }
        /// <summary>
        /// Testar se o e-mail é válido
        /// </summary>
        [Fact]
        public void TestarEmailValidoDoUsuario()
        {
            //Preparação
            Usuario usuario;

            // Execução
            usuario = new Usuario();
            usuario.Email = "email@email.edu";
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");


            // Retorno esperado
            Assert.Matches(regex, usuario.Email);
        }
    }
}
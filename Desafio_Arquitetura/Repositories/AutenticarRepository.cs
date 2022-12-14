using Desafio.Contexts;
using Desafio.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Desafio.Models;

namespace Desafio.Repositories
{
    public class AutenticarRepository : IAutenticarRepository
    {
        private readonly DesafioContext _context;

        public AutenticarRepository(DesafioContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método responsável por efetuar o Login do usuário a partir do Json recebido com e-mail e senha
        /// </summary>
        /// <param name="login">Dados do usuário para efetuar o login</param>
        /// <returns>Retorna um string com o Token gerado para autenticação</returns>
        public string Logar(Autenticar login)
        {
            var usuario = _context.Usuario
                .Where(u => u.Email == login.Email)
                .Include(u => u.Acesso)
                .Include(t => t.TipoUsuario)
                .FirstOrDefault();

            if (usuario != null && login.Senha != null && usuario.Senha.Contains("$2b$"))
            {
                bool validPassword = BCrypt.Net.BCrypt.Verify(login.Senha, usuario.Senha);
                if (validPassword)
                {
                    // Criar as credenciais do JWT

                    // Definições das Claims
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, usuario.Acesso.Nivel), // Colocar o nível de acesso de acordo com o nível do usuário
                        new Claim("Cargo", usuario.TipoUsuario.Tipo) // Identifica o cargo do usuário
                    };
                    // Criada a chave de criptografia
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("desafio-chave-autenticacao"));

                    // Criar as credenciais
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Gerar o token (objeto)
                    var token = new JwtSecurityToken(
                        issuer: "desafio.webAPI",
                        audience: "desafio.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                        );
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }
            return null;
        }
    }
}

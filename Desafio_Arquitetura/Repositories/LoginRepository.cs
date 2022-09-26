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
    public class LoginRepository : ILoginRepository
    {
        private readonly DesafioContext _context;

        public LoginRepository(DesafioContext context)
        {
            _context = context;
        }

        public string Logar(Login login)
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
                        new Claim(ClaimTypes.Role, usuario.Acesso.Nivel), // Colocar o nível de acesso
                        new Claim("Cargo", usuario.TipoUsuario.Tipo)

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

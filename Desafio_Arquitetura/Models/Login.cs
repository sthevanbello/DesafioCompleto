using System.ComponentModel.DataAnnotations;

namespace Desafio.Models
{
    /// <summary>
    /// Classe de Login para gerar o Json e servir de autenticador ne Login
    /// </summary>
    public class Login
    {
        [Required(ErrorMessage = "informe o e-mail do usuário")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Insira um e-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário")]
        [MinLength(6, ErrorMessage = "A senha deverá ter no mínimo 6 caracteres")]
        public string Senha { get; set; }
    }
}

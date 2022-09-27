using System.ComponentModel.DataAnnotations;

namespace Desafio.Models
{
    /// <summary>
    /// Classe para delimitar o Acesso ao sistema
    /// </summary>
    public class NiveisDeAcesso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nivel { get; set; }
    }
}

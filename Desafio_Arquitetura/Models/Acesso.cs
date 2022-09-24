using System.ComponentModel.DataAnnotations;

namespace Desafio_EF.Models
{
    public class Acesso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nivel { get; set; }
    }
}

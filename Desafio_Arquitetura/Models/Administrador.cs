using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Desafio.Models
{
    /// <summary>
    /// Model Administrador
    /// </summary>
    [DebuggerDisplay("{Id}: {Usuario.Nome} - {Usuario.Acesso.Nivel}")]
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [MinLength(11, ErrorMessage = "O CPF deverá conter exatamente 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O CPF deverá conter exatamente 11 caracteres")]
        public string CPF { get; set; }

        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}

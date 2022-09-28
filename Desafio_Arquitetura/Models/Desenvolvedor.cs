using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Desafio.Models
{
    /// <summary>
    /// Model Desenvolvedor
    /// </summary>
    [DebuggerDisplay("{Id}: {Usuario.Nome} - {Usuario.Acesso.Nivel}")]
    public class Desenvolvedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [MinLength(11, ErrorMessage = "O CPF deverá conter 11 caracteres e somente números")]
        [MaxLength(11, ErrorMessage = "O CPF deverá conter 11 caracteres e somente números")]
        public string CPF { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}

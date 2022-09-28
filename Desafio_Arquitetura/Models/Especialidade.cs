using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio.Models
{
    /// <summary>
    /// Model Especialidade
    /// </summary>
    public class Especialidade
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a categoria da especialidade")]
        public string Categoria { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Medico> Medicos { get; set; }
    }
}

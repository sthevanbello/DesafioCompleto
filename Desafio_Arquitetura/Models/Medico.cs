using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio.Models
{
    /// <summary>
    /// Model Medico
    /// </summary>
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CRM { get; set; }
        
        [Required(ErrorMessage ="Informe o Id da especialidade")]
        [ForeignKey("Especialidade")]
        public int IdEspecialidade { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Especialidade Especialidade { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }



        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Consulta> Consultas { get; set; }
    }
}

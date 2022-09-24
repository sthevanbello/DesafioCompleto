using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio_EF.Models
{
    /// <summary>
    /// Classe de relacionamento entre a classe Medico e a classe Paciente
    /// </summary>
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe a data da consulta")]
        public DateTime DataHora { get; set; }
        [Required(ErrorMessage ="Informe o Id do Médico da consulta")]
        [ForeignKey("Medico")]
        public int IdMedico { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Medico Medico { get; set; }
        [Required(ErrorMessage ="Informe o Id do paciente da consulta")]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Paciente Paciente { get; set; }
    }
}

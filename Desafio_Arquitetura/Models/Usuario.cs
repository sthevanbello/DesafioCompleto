using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio.Models
{
    /// <summary>
    /// Model Usuario - Esta classe não pode ser abstrata, pois para testar o Insert com xUnit, é necessário criar uma instância de um Usuário.
    /// <para>Tanto para Médico quanto para Paciente</para>
    /// </summary>
    public class Usuario
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "informe o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "informe o e-mail do usuário")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Insira um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário")]
        [MinLength(6, ErrorMessage = "A senha deverá ter no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [ForeignKey("TipoUsuario")]
        public int IdTipoUsuario { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TipoUsuario TipoUsuario { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [ForeignKey("Acesso")]
        public int IdAcesso { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NiveisDeAcesso Acesso { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Medico> Medicos { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ICollection<Paciente> Pacientes { get; set; }

    }
}

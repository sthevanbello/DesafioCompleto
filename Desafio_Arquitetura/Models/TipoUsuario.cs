using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio.Models
{
    /// <summary>
    /// Model TipoUsuario
    /// </summary>
    public class TipoUsuario
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}

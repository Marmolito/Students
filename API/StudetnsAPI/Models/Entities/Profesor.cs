using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudetnsAPI.Models.Entities
{
    public class Profesor
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Materia> Materias { get; set; } = new List<Materia>();
    }
}

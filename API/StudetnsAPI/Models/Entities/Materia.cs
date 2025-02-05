using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudetnsAPI.Models.Entities
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Creditos { get; set; } = 3;
        public int ProfesorId { get; set; }

        public Profesor Profesor { get; set; } = null!;

        [JsonIgnore]
        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}

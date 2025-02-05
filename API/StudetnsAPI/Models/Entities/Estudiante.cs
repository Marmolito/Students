using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudetnsAPI.Models.Entities
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        
        public List<Materia> Materias { get; set; } = new List<Materia>();
    }
}

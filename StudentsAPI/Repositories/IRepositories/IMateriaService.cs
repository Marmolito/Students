using StudetnsAPI.Models.Entities;

public interface IMateriaService
{
    Task<List<Materia>> ObtenerTodasAsync();
    Task<Materia?> ObtenerPorIdAsync(int id);
}

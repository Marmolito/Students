using StudetnsAPI.Models.Entities;

public interface IEstudianteService
{
    Task<List<Estudiante>> ObtenerTodosAsync();
    Task<Estudiante?> ObtenerPorIdAsync(int id);
    Task<bool> RegistrarEstudianteAsync(Estudiante estudiante, List<int> materiasIds);
}
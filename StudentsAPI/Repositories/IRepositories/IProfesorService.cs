using StudetnsAPI.Models.Entities;

public interface IProfesorService
{
    Task<List<Profesor>> ObtenerTodosAsync();
    Task<Profesor?> ObtenerPorIdAsync(int id);
}
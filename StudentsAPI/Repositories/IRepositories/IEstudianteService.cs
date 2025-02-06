using StudetnsAPI.Models.Dto;
using StudetnsAPI.Models.Entities;

public interface IEstudianteService
{
    Task<List<Estudiante>> ObtenerTodosAsync();
    Task<Estudiante?> ObtenerPorIdAsync(int id);
    Task<bool> RegistrarEstudianteAsync(RegistroMateriasDto estudiante);
}
using Microsoft.AspNetCore.Mvc;
using StudetnsAPI.Models.Entities;

[ApiController]
[Route("api/estudiantes")]
public class EstudianteController : ControllerBase
{
    private readonly IEstudianteService _estudianteService;

    public EstudianteController(IEstudianteService estudianteService)
    {
        _estudianteService = estudianteService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var estudiantes = await _estudianteService.ObtenerTodosAsync();
        return Ok(estudiantes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var estudiante = await _estudianteService.ObtenerPorIdAsync(id);
        if (estudiante == null) return NotFound();
        return Ok(estudiante);
    }

    [HttpPost]
    public async Task<IActionResult> Registrar([FromBody] Estudiante estudiante, [FromQuery] List<int> materiasIds)
    {
        var resultado = await _estudianteService.RegistrarEstudianteAsync(estudiante, materiasIds);
        if (!resultado) return BadRequest("Error en la selección de materias");
        return Ok("Estudiante registrado correctamente");
    }
}
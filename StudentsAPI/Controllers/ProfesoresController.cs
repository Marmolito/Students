using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/profesores")]
public class ProfesorController : ControllerBase
{
    private readonly IProfesorService _profesorService;

    public ProfesorController(IProfesorService profesorService)
    {
        _profesorService = profesorService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos()
    {
        var profesores = await _profesorService.ObtenerTodosAsync();
        return Ok(profesores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var profesor = await _profesorService.ObtenerPorIdAsync(id);
        if (profesor == null) return NotFound();
        return Ok(profesor);
    }
}

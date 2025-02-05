using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/materias")]
public class MateriaController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriaController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodas()
    {
        var materias = await _materiaService.ObtenerTodasAsync();
        return Ok(materias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var materia = await _materiaService.ObtenerPorIdAsync(id);
        if (materia == null) return NotFound();
        return Ok(materia);
    }
}
using Microsoft.EntityFrameworkCore;
using StudetnsAPI.Data;
using StudetnsAPI.Models.Entities;
using System;

public class EstudianteService : IEstudianteService
{
    private readonly ApplicationDbContext _context;

    public EstudianteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Estudiante>> ObtenerTodosAsync()
    {
        return await _context.Estudiantes.Include(e => e.Materias).ToListAsync();
    }

    public async Task<Estudiante?> ObtenerPorIdAsync(int id)
    {
        return await _context.Estudiantes.Include(e => e.Materias).FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> RegistrarEstudianteAsync(Estudiante estudiante, List<int> materiasIds)
    {
        if (materiasIds.Count != 3) return false;
        var materias = await _context.Materias.Where(m => materiasIds.Contains(m.Id)).ToListAsync();
        if (materias.Select(m => m.ProfesorId).Distinct().Count() != 3) return false;

        estudiante.Materias = materias;
        _context.Estudiantes.Add(estudiante);
        await _context.SaveChangesAsync();
        return true;
    }
}
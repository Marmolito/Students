using Microsoft.EntityFrameworkCore;
using StudetnsAPI.Data;
using StudetnsAPI.Models.Entities;
using System;
public class MateriaService : IMateriaService
{
    private readonly ApplicationDbContext _context;

    public MateriaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Materia>> ObtenerTodasAsync()
    {
        return await _context.Materias.Include(m => m.Profesor)
            .Include(m => m.Estudiantes)
            .Select(m => new Materia
        {
            Id = m.Id,
            Nombre = m.Nombre,
            Profesor = m.Profesor,
            Estudiantes = m.Estudiantes.Select(e => new Estudiante
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Email = e.Email
                // No incluimos la propiedad "Materias" aquí
            }).ToList()
        }).ToListAsync();
    }

    public async Task<Materia?> ObtenerPorIdAsync(int id)
    {
        return await _context.Materias.Include(m => m.Profesor).FirstOrDefaultAsync(m => m.Id == id);
    }
}
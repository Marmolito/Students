using Microsoft.EntityFrameworkCore;
using StudetnsAPI.Data;
using StudetnsAPI.Models.Entities;
using System;
public class ProfesorService : IProfesorService
{
    private readonly ApplicationDbContext _context;

    public ProfesorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Profesor>> ObtenerTodosAsync()
    {
        return await _context.Profesores.Include(p => p.Materias).ToListAsync();
    }

    public async Task<Profesor?> ObtenerPorIdAsync(int id)
    {
        return await _context.Profesores.Include(p => p.Materias).FirstOrDefaultAsync(p => p.Id == id);
    }
}
using Microsoft.EntityFrameworkCore;
using StudetnsAPI.Data;
using StudetnsAPI.Models.Dto;
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

    public async Task<bool> RegistrarEstudianteAsync(RegistroMateriasDto estudiante)
    {
        if (estudiante.materiasIds.Count != 3) return false;

        var materias = await _context.Materias.Where(m => estudiante.materiasIds.Contains(m.Id)).ToListAsync();
        if (materias.Select(m => m.ProfesorId).Distinct().Count() != 3) return false;

        if (estudiante.id == 0)
        {
            // Nuevo estudiante con exactamente 3 materias
            var estudianteEntity = new Estudiante()
            {
                Nombre = estudiante.nombre,
                Email = estudiante.email,
                Materias = materias
            };

            _context.Estudiantes.Add(estudianteEntity);
        }
        else
        {
            var estudianteExistente = await _context.Estudiantes.Include(e => e.Materias)
                                                                .FirstOrDefaultAsync(e => e.Id == estudiante.id);
            if (estudianteExistente == null) return false;
            estudianteExistente.Materias.Clear();
            estudianteExistente.Materias.AddRange(materias);
            if (estudianteExistente.Materias.Count != 3) return false;

            if (estudianteExistente.Materias.Select(m => m.ProfesorId).Distinct().Count() != 3) return false;
        }

        await _context.SaveChangesAsync();
        return true;
    }




}
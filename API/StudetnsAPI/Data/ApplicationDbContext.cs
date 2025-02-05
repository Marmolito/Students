using Microsoft.EntityFrameworkCore;
using StudetnsAPI.Models.Entities;


namespace StudetnsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Materia>()
                .HasMany(m => m.Estudiantes)
                .WithMany(e => e.Materias)
                .UsingEntity<Dictionary<string, object>>(
                    "EstudianteMateria",
                    j => j.HasOne<Estudiante>().WithMany().HasForeignKey("EstudianteId"),
                    j => j.HasOne<Materia>().WithMany().HasForeignKey("MateriaId"),
                    j => j.HasKey("EstudianteId", "MateriaId")
                );

            // Inserciones iniciales
            modelBuilder.Entity<Profesor>().HasData(
                new Profesor { Id = 1, Nombre = "Profesor A" },
                new Profesor { Id = 2, Nombre = "Profesor B" },
                new Profesor { Id = 3, Nombre = "Profesor C" },
                new Profesor { Id = 4, Nombre = "Profesor D" },
                new Profesor { Id = 5, Nombre = "Profesor E" }
            );

            modelBuilder.Entity<Materia>().HasData(
                new Materia { Id = 1, Nombre = "Matemáticas", ProfesorId = 1 },
                new Materia { Id = 2, Nombre = "Física", ProfesorId = 1 },
                new Materia { Id = 3, Nombre = "Química", ProfesorId = 2 },
                new Materia { Id = 4, Nombre = "Biología", ProfesorId = 2 },
                new Materia { Id = 5, Nombre = "Historia", ProfesorId = 3 },
                new Materia { Id = 6, Nombre = "Geografía", ProfesorId = 3 },
                new Materia { Id = 7, Nombre = "Inglés", ProfesorId = 4 },
                new Materia { Id = 8, Nombre = "Francés", ProfesorId = 4 },
                new Materia { Id = 9, Nombre = "Arte", ProfesorId = 5 },
                new Materia { Id = 10, Nombre = "Música", ProfesorId = 5 }
            );

            modelBuilder.Entity<Estudiante>().HasData(
                new Estudiante { Id = 1, Nombre = "Juan Pérez", Email = "juan.perez@example.com" },
                new Estudiante { Id = 2, Nombre = "María Gómez", Email = "maria.gomez@example.com" },
                new Estudiante { Id = 3, Nombre = "Carlos López", Email = "carlos.lopez@example.com" }
            );
        }

    }
}

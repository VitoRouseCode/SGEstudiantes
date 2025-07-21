using Microsoft.EntityFrameworkCore;

using SistemaEstudiantes.Core;


namespace SistemaEstudiantes.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}

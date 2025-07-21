using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SistemaEstudiantes.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // Puedes usar cualquier cadena de conexión aquí, es solo para las herramientas.
            optionsBuilder.UseSqlite("Data Source=design.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}


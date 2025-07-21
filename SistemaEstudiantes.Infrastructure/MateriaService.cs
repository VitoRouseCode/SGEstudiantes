using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Infrastructure
{
    public class MateriaService : IMateriaService
    {
        private readonly ApplicationDbContext _context;

        public MateriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Materia>> GetAllMaterias()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task CreateMateria(Materia materia)
        {
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();
        }
    }
}
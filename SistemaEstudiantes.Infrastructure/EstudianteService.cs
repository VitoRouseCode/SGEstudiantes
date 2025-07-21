using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Infrastructure
{
    public class EstudianteService : IEstudianteService
    {
        private readonly ApplicationDbContext _context;

        public EstudianteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudiantes()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante?> GetEstudianteById(int id)
        {
            return await _context.Estudiantes
                .Include(e => e.MateriasInscritas) // Incluye las materias en la consulta
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // MÉTODO NUEVO: Contiene la lógica de inscripción y validación.
        public async Task<bool> InscribirMaterias(int estudianteId, List<int> materiaIds)
        {
            var estudiante = await GetEstudianteById(estudianteId);
            if (estudiante == null) return false;

            var materiasNuevas = await _context.Materias
                .Where(m => materiaIds.Contains(m.Id))
                .ToListAsync();

            // Lógica de validación
            var materiasConCreditosAltos = estudiante.MateriasInscritas
                .Where(m => m.Creditos > 4)
                .ToList();

            var nuevasMateriasConCreditosAltos = materiasNuevas
                .Where(m => m.Creditos > 4 && !materiasConCreditosAltos.Any(existente => existente.Id == m.Id))
                .ToList();

            if (materiasConCreditosAltos.Count + nuevasMateriasConCreditosAltos.Count > 3)
            {
                // La validación falla: no puede tener más de 3 materias de más de 4 créditos.
                return false;
            }

            // Agrega las nuevas materias que no estén ya inscritas.
            foreach (var materia in materiasNuevas)
            {
                if (!estudiante.MateriasInscritas.Any(m => m.Id == materia.Id))
                {
                    estudiante.MateriasInscritas.Add(materia);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task CreateEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudiante(Estudiante estudiante)
        {
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesinscribirMateria(int estudianteId, int materiaId)
        {
            var estudiante = await GetEstudianteById(estudianteId);
            var materia = await _context.Materias.FindAsync(materiaId);

            if (estudiante != null && materia != null)
            {
                estudiante.MateriasInscritas.Remove(materia);
                await _context.SaveChangesAsync();
            }
        }


    }
}
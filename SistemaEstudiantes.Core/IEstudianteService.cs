using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Core
{
    public interface IEstudianteService
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiantes();
        Task<Estudiante?> GetEstudianteById(int id);
        Task CreateEstudiante(Estudiante estudiante);
        Task UpdateEstudiante(Estudiante estudiante);
        Task DeleteEstudiante(int id);
        Task<bool> InscribirMaterias(int estudianteId, List<int> materiaIds);
        Task DesinscribirMateria(int estudianteId, int materiaId);
    }
}
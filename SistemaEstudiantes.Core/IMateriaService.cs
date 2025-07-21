using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Core
{
    public interface IMateriaService
    {
        Task<IEnumerable<Materia>> GetAllMaterias();
        Task CreateMateria(Materia materia);
    }
}
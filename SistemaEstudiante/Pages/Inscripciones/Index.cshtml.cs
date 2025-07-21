using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Inscripciones
{
    public class IndexModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        public IEnumerable<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public IndexModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task OnGetAsync()
        {
            Estudiantes = await _estudianteService.GetAllEstudiantes();
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Estudiantes
{
    public class IndexModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        // Propiedad para pasar la lista de estudiantes a la vista
        public IEnumerable<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        // El servicio se inyecta automáticamente aquí
        public IndexModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // Este método se ejecuta cuando se carga la página
        public async Task OnGetAsync()
        {
            Estudiantes = await _estudianteService.GetAllEstudiantes();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Estudiantes
{
    public class CreateModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        // [BindProperty] conecta esta propiedad con los campos del formulario
        [BindProperty]
        public Estudiante Estudiante { get; set; } = new();

        public CreateModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // Este método solo muestra la página con el formulario vacío
        public void OnGet()
        {
        }

        // Este método se ejecuta cuando se envía el formulario (POST)
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si hay errores de validación, muestra el formulario de nuevo
            }

            await _estudianteService.CreateEstudiante(Estudiante);

            return RedirectToPage("./Index"); // Redirige a la lista de estudiantes
        }
    }
}
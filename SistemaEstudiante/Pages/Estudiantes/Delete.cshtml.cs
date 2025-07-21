using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Estudiantes
{
    public class DeleteModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;

        [BindProperty]
        public Estudiante Estudiante { get; set; } = new();

        public DeleteModel(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteById(id);

            if (estudiante == null)
            {
                return NotFound();
            }
            Estudiante = estudiante;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _estudianteService.DeleteEstudiante(id);

            return RedirectToPage("./Index");
        }
    }
}
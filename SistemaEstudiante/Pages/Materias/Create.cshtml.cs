using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Materias
{
    public class CreateModel : PageModel
    {
        private readonly IMateriaService _materiaService;

        [BindProperty]
        public Materia Materia { get; set; } = new();

        public CreateModel(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _materiaService.CreateMateria(Materia);

            return RedirectToPage("./Index");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Inscripciones
{
    public class InscribirModel : PageModel
    {
        private readonly IEstudianteService _estudianteService;
        private readonly IMateriaService _materiaService;

        public Estudiante Estudiante { get; set; } = new();
        public List<Materia> MateriasDisponibles { get; set; } = new();

        [BindProperty]
        public List<int> MateriasSeleccionadas { get; set; } = new();

        public InscribirModel(IEstudianteService estudianteService, IMateriaService materiaService)
        {
            _estudianteService = estudianteService;
            _materiaService = materiaService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteById(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            Estudiante = estudiante;
            MateriasDisponibles = (await _materiaService.GetAllMaterias()).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var exito = await _estudianteService.InscribirMaterias(id, MateriasSeleccionadas);

            if (!exito)
            {
                // Si la inscripción falla (por la validación), recargamos la página con un error.
                ModelState.AddModelError(string.Empty, "La inscripción falló. Un estudiante no puede tener más de 3 materias con más de 4 créditos.");

            
                var estudiante = await _estudianteService.GetEstudianteById(id);
                if (estudiante == null) return NotFound();

                Estudiante = estudiante;
                MateriasDisponibles = (await _materiaService.GetAllMaterias()).ToList();

                return Page();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostRemoverMateriaAsync(int id, int materiaId)
        {
            await _estudianteService.DesinscribirMateria(id, materiaId);
            return RedirectToPage(new { id = id });
        }
    }
}
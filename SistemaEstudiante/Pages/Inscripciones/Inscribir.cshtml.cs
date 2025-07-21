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
                // Si la inscripci�n falla (por la validaci�n), recargamos la p�gina con un error.
                ModelState.AddModelError(string.Empty, "La inscripci�n fall�. Un estudiante no puede tener m�s de 3 materias con m�s de 4 cr�ditos.");

            
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
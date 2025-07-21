using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaEstudiantes.Core;

namespace SistemaEstudiantes.Web.Pages.Materias
{
    public class IndexModel : PageModel
    {
        private readonly IMateriaService _materiaService;

        public IEnumerable<Materia> Materias { get; set; } = new List<Materia>();

        public IndexModel(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        public async Task OnGetAsync()
        {
            Materias = await _materiaService.GetAllMaterias();
        }
    }
}
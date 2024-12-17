using GestionEmpleados.Data;
using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEmpleados.Pages.Empleados
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Empleado Empleado { get; set; }

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id)
        {
            Empleado = await _context.Empleados.FindAsync(id);
        }
    }
}
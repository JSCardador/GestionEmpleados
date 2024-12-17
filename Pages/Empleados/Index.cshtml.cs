using GestionEmpleados.Data;
using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpleados.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Empleado> Empleados { get; set; } = new();

        public async Task OnGetAsync()
        {
            Empleados = await _context.Empleados.ToListAsync();
        }
    }
}
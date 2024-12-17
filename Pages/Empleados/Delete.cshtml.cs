using GestionEmpleados.Data;
using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEmpleados.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Empleado Empleado { get; set; } = new();

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Empleado = await _context.Empleados.FindAsync(id);

            if (Empleado == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var empleadoToDelete = await _context.Empleados.FindAsync(id);

            if (empleadoToDelete == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleadoToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
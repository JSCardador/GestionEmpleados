using GestionEmpleados.Data;
using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEmpleados.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Empleado Empleado { get; set; } = new();

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
using GestionEmpleados.Data;
using GestionEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpleados.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Empleado Empleado { get; set; }
        private int currentEmpleadoId;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Empleado = await _context.Empleados.FindAsync(id);

            currentEmpleadoId = id;

            if (Empleado == null)
            {
                return NotFound("Empleado no encontrado");
            }

            Console.WriteLine("-----> GET " + Empleado.Nombre + " " + Empleado.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var empleadoExistente = await _context.Empleados.FindAsync(id);

            if (empleadoExistente == null)
            {
                return NotFound("Empleado no encontrado");
            }

            // Actualiza los valores
            Empleado.Id = id;   
            _context.Entry(empleadoExistente).CurrentValues.SetValues(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using GestionEmpleados.Models;

namespace GestionEmpleados.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
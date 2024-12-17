using Microsoft.EntityFrameworkCore;
using GestionEmpleados.Models;

namespace GestionEmpleados.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();  
        }
    }
}
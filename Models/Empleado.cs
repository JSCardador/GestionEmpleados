using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models
{
    public class Empleado
    {
        [Key]
        public  int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
    }
}
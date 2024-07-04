using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Administrador
    {

        [Key]
        public int Cedula { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }

    }
}

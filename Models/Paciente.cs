using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Paciente
    {
        [Key]
        public int Cedula { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        

    }
}

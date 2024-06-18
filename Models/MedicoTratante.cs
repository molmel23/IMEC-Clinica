using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class MedicoTratante
    {
        [Key]
        public int NumeroColegiado { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public string FotoURL { get; set; }

    }
}

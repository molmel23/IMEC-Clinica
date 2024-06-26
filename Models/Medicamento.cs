using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Medicamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }



    }
}

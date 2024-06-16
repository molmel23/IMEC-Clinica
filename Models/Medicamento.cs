using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Medicamento
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }



    }
}

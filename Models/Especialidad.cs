using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramadoLenguajes2024.Models
{
    
    public class Especialidad
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
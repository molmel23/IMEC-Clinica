using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Cedula { get; set; }

    }
}

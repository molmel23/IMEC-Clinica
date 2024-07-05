using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramadoLenguajes2024.Models.ApisModels
{
    public class IngresarUsuario
    {

        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido.")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
        public string ContraUsuario { get; set; }
    }
}


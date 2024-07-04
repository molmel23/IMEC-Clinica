using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class UsuariosVM
    {

        [ValidateNever]
        public PacienteVM PacienteVM { get; set; }

        [ValidateNever]
        public MedicoTratanteVM MedicoTratanteVM { get; set; }

        [ValidateNever]

        public AdministradorVM AdministradorVM { get; set; }


    }
}

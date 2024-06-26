using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class PacienteVM
    {
        [ValidateNever]
        public Paciente Paciente { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> PacientesList { get; set; }
    }
}

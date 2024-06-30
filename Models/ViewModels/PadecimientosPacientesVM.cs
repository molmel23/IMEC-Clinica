using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class PadecimientosPacientesVM
    {
        [ValidateNever]
        public PadecimientosPacientes PadecimientoPaciente { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> PadecimientosPacientesList { get; set; }

    }
}

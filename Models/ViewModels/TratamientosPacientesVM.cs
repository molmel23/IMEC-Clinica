using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class TratamientosPacientesVM
    {
        [ValidateNever]
        public TratamientosPacientes TratamientosPacientes { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> TratamientosPacientesList { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class MedicamentosPacientesVM
    {
        [ValidateNever]
        public MedicamentosPacientes MedicamentosPacientes { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> MedicamentosPacientesList { get; set; }
    }
}

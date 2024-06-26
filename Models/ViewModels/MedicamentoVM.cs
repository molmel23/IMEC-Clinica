using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class MedicamentoVM
    {
        [ValidateNever]
        public Medicamento Medicamento { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> MedicamentoList { get; set; }
    }
}

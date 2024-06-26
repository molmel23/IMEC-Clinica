using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class ExpedienteVM
    {
        [ValidateNever]
        public Expediente Expediente { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> ExpedienteList { get; set; }
    }
}

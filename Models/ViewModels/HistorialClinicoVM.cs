using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class HistorialClinicoVM
    {
        [ValidateNever]
        public HistorialClinico HistorialClinico { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> HistorialClinicoList { get; set; }
    }
}

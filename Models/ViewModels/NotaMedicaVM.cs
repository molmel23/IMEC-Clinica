using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class NotaMedicaVM
    {
        [ValidateNever]
        public NotaMedica NotaMedica { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> NotaMedicaList { get; set; }
    }
}

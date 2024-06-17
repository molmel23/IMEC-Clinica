using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class EspecialidadVM
    {

        [ValidateNever]
        public Especialidad Especialidad { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> EspecialidadList { get; set; }
    }
}

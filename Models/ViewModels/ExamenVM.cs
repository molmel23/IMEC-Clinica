using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class ExamenVM
    {

        [ValidateNever]
        public Examen Examen { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> ExamenList { get; set; }
    }
}

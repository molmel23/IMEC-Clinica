using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class ResultadosExamenesVM
    {
        [ValidateNever]
        public ResultadosExamenes ResultadosExamenes { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> ResultadosExamenesList { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class TratamientoVM
    {
        [ValidateNever]
        public Tratamiento Tratamiento { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> TratamientoList { get; set; }
    }
}

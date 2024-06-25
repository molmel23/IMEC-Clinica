using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class PadecimientoVM
    {

        [ValidateNever]
        public Padecimiento Padecimiento { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> PadecimientoList { get; set; }
    }
}

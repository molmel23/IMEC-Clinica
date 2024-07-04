using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class AdministradorVM
    {
        [ValidateNever]
        public Administrador Administrador { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> AdministradorList { get; set; }


    }
}

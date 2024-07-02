using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class MedicoTratanteVM
    {
        [ValidateNever]
        public MedicoTratante MedicoTratante { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> MedicoTratanteList { get; set; }

        [ValidateNever]
        public int Especialidad { get; set; }

    }
}

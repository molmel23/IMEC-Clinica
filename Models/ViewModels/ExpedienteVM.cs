using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProyectoProgramadoLenguajes2024.Models.ViewModels
{
    public class ExpedienteVM
    {
        [ValidateNever]
        public PacienteVM PacienteVM { get; set; }
      
        [ValidateNever]
        public PadecimientoVM PadecimientoVM { get; set; }

        [ValidateNever]
        public PadecimientosPacientesVM PadecimientosPacientesVM { get; set; }
        
        [ValidateNever]
        public TratamientoVM TratamientoVM { get; set; }

        [ValidateNever]
        public TratamientosPacientesVM TratamientosPacientesVM { get; set; }
        
        [ValidateNever]
        public MedicamentoVM MedicamentoVM { get; set; }

        [ValidateNever]
        public MedicamentosPacientesVM MedicamentosPacientesVM { get; set; }
       
        [ValidateNever]
        public ExamenVM ExamenVM { get; set; }

        [ValidateNever]
        public NotaMedicaVM NotaMedicaVM { get; set; }

        [ValidateNever]
        public MedicoTratanteVM MedicoTratanteVM { get; set; }

    }
}

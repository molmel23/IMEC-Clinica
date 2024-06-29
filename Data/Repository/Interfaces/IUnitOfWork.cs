using Microsoft.AspNetCore.Mvc;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
     
        void Save();

        IEspecialidadRepository Especialidades { get; }
        IMedicoTratanteRepository MedicoTratantes { get; }
        IEspecialidad_MedicoTratanteRepository Especialidades_MedicoTratantes { get; }
        IPadecimientoRepository Padecimiento { get; }
        ITratamientoRepository Tratamiento { get; }
        IMedicamentoRepository Medicamento { get; }
        IPacienteRepository Pacientes { get; }
        ITratamientosPacientesRepository TratamientosPacientes { get; }
        IPadecimientosPacientesRepository PadecimientosPacientes { get; }
        IMedicamentosPacientesRepository MedicamentosPacientes { get; }


    }
}

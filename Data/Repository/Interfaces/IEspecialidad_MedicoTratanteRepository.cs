using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IEspecialidad_MedicoTratanteRepository : IRepository<Especialidad_MedicoTratante>
    {
        void Update(Especialidad_MedicoTratante especialidad_MedicoTratante);
    }
}

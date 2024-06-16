using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IEspecialidadRepository : IRepository<Especialidad>
    {
        void Update(Especialidad especialidad);
    }
}

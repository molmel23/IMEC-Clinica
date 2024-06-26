using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IHistorialClinicoRepository : IRepository<HistorialClinico>
    {
        void Update(HistorialClinico historialClinico);
    }
}

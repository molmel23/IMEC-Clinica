using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IExamenRepository : IRepository<Examen>
    {
      void Update(Examen examen);
    }
}

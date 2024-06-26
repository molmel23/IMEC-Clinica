using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface ITratamientoRepository : IRepository<Tratamiento>
    {
        void Update(Tratamiento tratamiento);
    }
}

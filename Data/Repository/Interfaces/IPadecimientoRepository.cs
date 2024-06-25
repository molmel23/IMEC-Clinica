using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IPadecimientoRepository : IRepository<Padecimiento>
    {
        void Update(Padecimiento padecimiento);
    }
}

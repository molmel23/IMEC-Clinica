using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface ITratamientosPacientesRepository : IRepository<TratamientosPacientes>
    {
        void Update(TratamientosPacientes tratamientosPacientes);
    }
}

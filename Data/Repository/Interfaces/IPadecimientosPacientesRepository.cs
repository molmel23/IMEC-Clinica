using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IPadecimientosPacientesRepository : IRepository<PadecimientosPacientes>
    {
        void Update(PadecimientosPacientes padecimientosPacientes);
    }
}

using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IMedicamentosPacientesRepository : IRepository<MedicamentosPacientes>
    {
        void Update(MedicamentosPacientes medicamentosPacientes);
    }
}

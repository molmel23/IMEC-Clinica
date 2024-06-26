using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IExpedienteRepository : IRepository<Expediente>
    {
        void Update(Expediente expediente);
    }
}

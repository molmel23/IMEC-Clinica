using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IMedicoTratanteRepository : IRepository<MedicoTratante>
    {
        void Update(MedicoTratante medicoTratante);
    }
}

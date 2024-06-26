using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface INotaMedicaRepository : IRepository<NotaMedica>
    {
        void Update(NotaMedica  notaMedica);
    }
}

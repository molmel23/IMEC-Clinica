using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IAdministradoresRepository : IRepository<Administrador>
    {
        void Update(Administrador administrador);
    }
}

using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IResultadosExamenesRepository : IRepository<ResultadosExamenes>
    {
        void Update(ResultadosExamenes resultadosExamenes);
    }
}

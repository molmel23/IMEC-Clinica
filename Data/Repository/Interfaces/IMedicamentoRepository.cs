using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IMedicamentoRepository: IRepository<Medicamento>
    {
        void Update(Medicamento medicamento);
    }
}

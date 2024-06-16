using Microsoft.AspNetCore.Mvc;

namespace ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
     
        void Save();

        IEspecialidadRepository Especialidades { get; }


    }
}

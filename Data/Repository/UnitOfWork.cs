using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Especialidades = new EspecialidadRepository(_db);
            
        }

        public IEspecialidadRepository Especialidades { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
    
    }


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
            MedicoTratantes = new MedicoTratanteRepository(_db);
            Especialidades_MedicoTratantes = new Especialidad_MedicoTratanteRepository(_db);
            Padecimiento = new PadecimientoRepository(_db);

        }

        public IEspecialidadRepository Especialidades { get; }
        public IMedicoTratanteRepository MedicoTratantes { get; }
        public IEspecialidad_MedicoTratanteRepository Especialidades_MedicoTratantes { get; }

        public IPadecimientoRepository Padecimiento { get; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
    
    }


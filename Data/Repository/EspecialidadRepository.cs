using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class EspecialidadRepository : Repository<Especialidad>, IEspecialidadRepository
    {
        private ApplicationDbContext _db;

        public EspecialidadRepository(ApplicationDbContext db) : base(db)
        {
        _db = db;
        }

        public void Update(Especialidad especialidad)
        {
        _db.Especialidades.Update(especialidad);
        }

        
    }
}
    

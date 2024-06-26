using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class HistorialClinicoRepository : Repository<HistorialClinico>, IHistorialClinicoRepository
    {
        private ApplicationDbContext _db;

        public HistorialClinicoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(HistorialClinico HistorialClinico)
        {
            _db.HistorialClinico.Update(HistorialClinico);
        }


    }
}

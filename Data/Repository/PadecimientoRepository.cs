using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class PadecimientoRepository : Repository<Padecimiento>, IPadecimientoRepository
    {
        private ApplicationDbContext _db;

        public PadecimientoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Padecimiento padecimiento)
        {
            _db.Padecimiento.Update(padecimiento);
        }
    }
}

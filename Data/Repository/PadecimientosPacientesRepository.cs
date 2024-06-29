using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class PadecimientosPacientesRepository : Repository<PadecimientosPacientes>, IPadecimientosPacientesRepository
    {
        private ApplicationDbContext _db;

        public PadecimientosPacientesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PadecimientosPacientes padecimientosPacientes)
        {
            _db.PadecimientosPacientes.Update(padecimientosPacientes);
        }

    }
}

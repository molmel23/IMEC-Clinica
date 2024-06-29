using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class TratamientosPacientesRepository : Repository<TratamientosPacientes>, ITratamientosPacientesRepository
    {
        private ApplicationDbContext _db;

        public TratamientosPacientesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TratamientosPacientes tratamientosPacientes)
        {
            _db.TratamientosPacientes.Update(tratamientosPacientes);
        }
    }
}

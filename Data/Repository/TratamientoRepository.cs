using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class TratamientoRepository : Repository<Tratamiento>, ITratamientoRepository
    {
        private ApplicationDbContext _db;

        public TratamientoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tratamiento tratamiento)
        {
            _db.Tratamiento.Update(tratamiento);
        }
    }
}

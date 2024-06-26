using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class NotaMedicaRepository : Repository<NotaMedica>, INotaMedicaRepository
    {
        private ApplicationDbContext _db;

        public NotaMedicaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(NotaMedica NotaMedica)
        {
            _db.NotaMedica.Update(NotaMedica);
        }


    }
}

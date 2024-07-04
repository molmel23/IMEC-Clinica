using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class AdministradorRepository : Repository<Administrador>, IAdministradoresRepository
    {
        private ApplicationDbContext _db;

        public AdministradorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Administrador administrador)
        {
            _db.Administrador.Update(administrador);
        }
    }
}

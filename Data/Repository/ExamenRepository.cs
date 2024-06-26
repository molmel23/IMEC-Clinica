using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class ExamenRepository : Repository<Examen>, IExamenRepository
    {
        private ApplicationDbContext _db;

    public ExamenRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Examen examen)
    {
        _db.Examen.Update(examen);
    }

       
    }
}

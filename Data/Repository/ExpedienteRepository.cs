using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class ExpedienteRepository : Repository<Expediente>, IExpedienteRepository
    {
        private ApplicationDbContext _db;

        public ExpedienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Expediente expediente)
        {
            _db.Expediente.Update(expediente);
        }


    }
}

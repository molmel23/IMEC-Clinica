using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        private ApplicationDbContext _db;

        public PacienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Paciente paciente)
        {
            _db.Paciente.Update(paciente);
        }
    }
}

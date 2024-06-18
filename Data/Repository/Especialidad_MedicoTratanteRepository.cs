using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class Especialidad_MedicoTratanteRepository : Repository<Especialidad_MedicoTratante>, IEspecialidad_MedicoTratanteRepository
    {
        private ApplicationDbContext _db;

        public Especialidad_MedicoTratanteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Especialidad_MedicoTratante especialidad_MedicoTratante)
        {
            _db.Especialidades_MedicoTratantes.Update(especialidad_MedicoTratante);
        }
    }
}

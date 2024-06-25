using Microsoft.EntityFrameworkCore;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class MedicoTratanteRepository : Repository<MedicoTratante>, IMedicoTratanteRepository
    {
        private ApplicationDbContext _db;

        public MedicoTratanteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MedicoTratante medicoTratante)
        {

            var entry = _db.Entry(medicoTratante);
            if (entry.State == EntityState.Detached)
            {
                _db.Attach(medicoTratante);
                entry.State = EntityState.Modified;
            }
            _db.MedicoTratantes.Update(medicoTratante);

        }
    }

}


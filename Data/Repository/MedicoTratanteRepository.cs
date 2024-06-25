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
            _db.MedicoTratantes.Update(medicoTratante);

        }
    }

}


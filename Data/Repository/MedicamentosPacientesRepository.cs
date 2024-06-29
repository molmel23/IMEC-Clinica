using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class MedicamentosPacientesRepository : Repository<MedicamentosPacientes>, IMedicamentosPacientesRepository
    {
        private ApplicationDbContext _db;

        public MedicamentosPacientesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MedicamentosPacientes medicamentosPacientes)
        {
            _db.MedicamentosPacientes.Update(medicamentosPacientes);
        }
    }
}

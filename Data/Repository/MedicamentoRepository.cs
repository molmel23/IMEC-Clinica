using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class MedicamentoRepository : Repository<Medicamento>, IMedicamentoRepository
    {

        private ApplicationDbContext _db;

        public MedicamentoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Medicamento medicamento)
        {
            _db.Medicamento.Update(medicamento);
        }
    }
}

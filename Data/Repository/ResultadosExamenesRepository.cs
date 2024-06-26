using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class ResultadosExamenesRepository : Repository<ResultadosExamenes>, IResultadosExamenesRepository
    {
        private ApplicationDbContext _db;

        public ResultadosExamenesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ResultadosExamenes ResultadosExamenes)
        {
            _db.ResultadosExamenes.Update(ResultadosExamenes);
        }


    }
}

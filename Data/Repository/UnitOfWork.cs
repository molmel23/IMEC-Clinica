using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;
using System.Security.Permissions;

namespace ProyectoProgramadoLenguajes2024.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Especialidades = new EspecialidadRepository(_db);
            MedicoTratantes = new MedicoTratanteRepository(_db);
            Especialidades_MedicoTratantes = new Especialidad_MedicoTratanteRepository(_db);
            Padecimiento = new PadecimientoRepository(_db);
            Tratamiento = new TratamientoRepository(_db);
            Medicamento = new MedicamentoRepository(_db);
            Pacientes = new PacienteRepository(_db);
            Examenes = new ExamenRepository(_db);
            Expedientes = new ExpedienteRepository(_db);
            HistorialesClinicos = new HistorialClinicoRepository(_db);
            NotasMedicas = new NotaMedicaRepository(_db);
            ResultadosExamenes = new ResultadosExamenesRepository(_db);


        }

        public IEspecialidadRepository Especialidades { get; }
        public IMedicoTratanteRepository MedicoTratantes { get; }
        public IEspecialidad_MedicoTratanteRepository Especialidades_MedicoTratantes { get; }
        public IPadecimientoRepository Padecimiento { get; }
        public ITratamientoRepository Tratamiento { get; }
        public IMedicamentoRepository Medicamento { get; }
        public IPacienteRepository Pacientes { get; }
        public IExamenRepository Examenes { get; }
        public IExpedienteRepository Expedientes { get; }
        public IHistorialClinicoRepository HistorialesClinicos { get; }
        public INotaMedicaRepository NotasMedicas { get; }
        public IResultadosExamenesRepository ResultadosExamenes { get; }




        public void Save()
        {
            _db.SaveChanges();
        }
    }
    
    }


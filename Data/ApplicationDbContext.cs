
using Microsoft.EntityFrameworkCore;
using ProyectoProgramadoLenguajes2024.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProyectoProgramadoLenguajes2024.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<MedicoTratante> MedicoTratantes { get; set; }
        public DbSet<Especialidad_MedicoTratante> Especialidades_MedicoTratantes { get; set; }
        public DbSet<Padecimiento> Padecimiento { get; set; }
        public DbSet<Tratamiento> Tratamiento { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Examen> Examen { get; set; }
        public DbSet<NotaMedica> NotaMedica { get; set; }
        public DbSet<PadecimientosPacientes> PadecimientosPacientes { get; set; }
        public DbSet<MedicamentosPacientes> MedicamentosPacientes { get; set; }
        public DbSet<TratamientosPacientes> TratamientosPacientes { get; set; }

        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de la clave primaria compuesta
            modelBuilder.Entity<Especialidad_MedicoTratante>()
                .HasKey(e => new { e.MedicoTratanteId, e.EspecialidadId });
        }

    }
}
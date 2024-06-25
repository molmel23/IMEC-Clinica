using Microsoft.AspNetCore.Mvc;
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
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Padecimiento> Padecimiento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de la clave primaria compuesta
            modelBuilder.Entity<Especialidad_MedicoTratante>()
                .HasKey(e => new { e.MedicoTratanteId, e.EspecialidadId });
        }

    }
}
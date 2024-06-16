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


    }
}
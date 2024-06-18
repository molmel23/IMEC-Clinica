using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Especialidad_MedicoTratante
    {
        public int MedicoTratanteId { get; set; }

        public int EspecialidadId { get; set; }

        [ForeignKey("MedicoTratanteId")]
        public MedicoTratante MedicoTratante { get; set; }

        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }
    }
}

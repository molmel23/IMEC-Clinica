using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class TratamientosPacientes
    {
        [Key]
        public int Id { get; set; }

        public int IdTratamiento { get; set; }
        [ForeignKey("IdTratamiento")]
        public Tratamiento Tratamiento { get; set; }

        public int CedulaPaciente { get; set; }
        [ForeignKey("CedulaPaciente")]
        public Paciente Paciente { get; set; }

        public int NumeroColegiadoMedico { get; set; }

        [ForeignKey("NumeroColegiadoMedico")]
        public MedicoTratante MedicoTratante { get; set; }
    }
}

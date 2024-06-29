using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class MedicamentosPacientes
    {
        [Key]
        public int Id { get; set; }

        public int IdMedicamento { get; set; }
        [ForeignKey("IdMedicamento")]
        public Medicamento Medicamento { get; set; }

        public int CedulaPaciente { get; set; }
        [ForeignKey("CedulaPaciente")]
        public Paciente Paciente { get; set; }

        public int NumeroColegiadoMedico { get; set; }

        [ForeignKey("NumeroColegiadoMedico")]
        public MedicoTratante MedicoTratante { get; set; }
    }
}

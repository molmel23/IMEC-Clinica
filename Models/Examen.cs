using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Examen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string ArchivoURL { get; set; }

        public int NumeroColegiadoMedico { get; set; }

        [ForeignKey("NumeroColegiadoMedico")]
        public MedicoTratante MedicoTratante { get; set; }

        public int CedulaPaciente { get; set; }
        [ForeignKey("CedulaPaciente")]
        public Paciente Paciente { get; set; }
    }
}

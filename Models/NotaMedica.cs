using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class NotaMedica
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public int NumeroColegiadoMedico { get; set; }

        [ForeignKey("NumeroColegiadoMedico")]
        public MedicoTratante MedicoTratante { get; set; }

        public int CedulaPaciente { get; set; }
        [ForeignKey("CedulaPaciente")]
        public Paciente Paciente { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class Expediente
    {
        public int cedulaPaciente { get; set; }

        [ForeignKey("CedulaPaciente")]
        public Paciente Paciente { get; set; }

        [Required]
        public List<Padecimiento> ListaPadecimientos { get; set; }
        [Required]
        public List<Tratamiento> ListaTratamientos { get; set; }
        [Required]
        public List<Medicamento> ListaMedicamentos { get; set; }
        [Required]
        public List<ResultadosExamenes> ListaResultadosExamenes { get; set; }
        [Required]
        public List<HistorialClinico> ListaHistorialClinico { get; set; }
    }
}

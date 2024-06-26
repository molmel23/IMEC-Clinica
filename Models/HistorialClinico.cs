using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramadoLenguajes2024.Models
{
    public class HistorialClinico
    {
        List<NotaMedica> NotasMedicas { get; set; }

    }
}

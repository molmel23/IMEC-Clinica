using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;

namespace ProyectoProgramadoLenguajes2024.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    [EnableCors("AllowAnyOrigin")]
    public class MedicamentosController : Controller
    {

        [HttpGet]
        [EnableCors("AllowAnyOrigin")]
        public IActionResult GetMedicamentos(int id)
        {
            var unitOfWork = HttpContext.RequestServices.GetService<IUnitOfWork>() as IUnitOfWork;

            var medicamentos = unitOfWork.MedicamentosPacientes.GetAll(includeProperties: "Medicamento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = medicamentos });
        }
    }
}

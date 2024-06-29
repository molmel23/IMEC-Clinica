using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Medicina.Controllers
{
    [Area("Medicina")]
    [Authorize(Roles = Roles.Medico)]
    public class BienvenidaController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BienvenidaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var pacientesList = _unitOfWork.Pacientes.GetAll().Select(c => new {
                c.Cedula,
                c.NombreCompleto,
                c.CorreoElectronico
            });
            return Json(new { data = pacientesList });

        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Medicina.Controllers
{
    [Area("Medicina")]
    [Authorize(Roles = Roles.Medico)]

    public class PacienteController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private int pacienteActual;

        public PacienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var pacientesList = _unitOfWork.Pacientes.GetAll().Select(c => new
            {
                c.Cedula,
                c.NombreCompleto,
                c.CorreoElectronico
            });
            return Json(new { data = pacientesList });

        }

        [HttpGet]
        public ActionResult Expediente(int id)
        {
            var paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id);
            pacienteActual = paciente.Cedula;
            return View(paciente);
        }

        public ActionResult GetPadecimientos()
        {
            var padecimientos = _unitOfWork.PadecimientosPacientes.GetAll().Select(c => new
            {
                c.Id,
                c.CedulaPaciente,
                c.NumeroColegiadoMedico
            }).Where(x => x.CedulaPaciente == pacienteActual);
            return Json(new { data = padecimientos });
        }

        [HttpGet]
        public ActionResult Padecimientos()
        {
            return View();
        }

        public IActionResult Delete(int? id)
        {
            var pacienteToDelete = _unitOfWork.Pacientes.Get(x => x.Cedula == id);

            if (pacienteToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar el tratamiento" });
            }

            _unitOfWork.Pacientes.Remove(pacienteToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Tratamiento borrado exitosamente" });
        }

    }
}

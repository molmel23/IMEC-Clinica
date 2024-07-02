using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Medicina.Controllers
{
    [Area("Medicina")]
    [Authorize(Roles = Roles.Medico)]
    public class PacienteController : Controller
    {
        private IUnitOfWork _unitOfWork;

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
            return View(paciente);
        }

        [HttpGet]
        public ActionResult GetPadecimientos(int id)
        {
            var padecimientos = _unitOfWork.PadecimientosPacientes.GetAll(includeProperties: "Padecimiento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = padecimientos });
        }

        [HttpGet]
        public ActionResult Padecimientos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

        [HttpGet]
        public ActionResult AgregarPadecimientos(int id)
        {
            PadecimientosPacientesVM model = new PadecimientosPacientesVM
            {
                PadecimientoPaciente = new PadecimientosPacientes
                {
                    CedulaPaciente = id
                },
            };
            ViewData["Padecimientos"] = _unitOfWork.Padecimiento.GetAll();
            ViewData["Medicos"] = _unitOfWork.MedicoTratantes.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarPadecimientos(PadecimientosPacientesVM model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PadecimientosPacientes.Add(model.PadecimientoPaciente);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Padecimientos), new { id = model.PadecimientoPaciente.CedulaPaciente });
            }
            ViewData["Padecimientos"] = _unitOfWork.Padecimiento.GetAll();
            ViewData["Medicos"] = _unitOfWork.MedicoTratantes.GetAll();
            return View(model);
        }

        public IActionResult SuspenderPadecimiento(int? id)
        {
            var padecimientoToDelete = _unitOfWork.PadecimientosPacientes.Get(x => x.Id == id);

            if (padecimientoToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar" });
            }

            _unitOfWork.PadecimientosPacientes.Remove(padecimientoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Borrado exitosamente" });
        }

        public IActionResult Delete(int? id)
        {
            var pacienteToDelete = _unitOfWork.Pacientes.Get(x => x.Cedula == id);

            if (pacienteToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar paciente" });
            }

            _unitOfWork.Pacientes.Remove(pacienteToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Paciente borrado exitosamente" });
        }
    }
}

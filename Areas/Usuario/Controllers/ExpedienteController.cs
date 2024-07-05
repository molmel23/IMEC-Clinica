using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    [Authorize(Roles = Roles.Usuario)]
    public class ExpedienteController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ExpedienteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id)
        {
            ViewData["PacienteId"] = id;
            ExpedienteVM model = new ExpedienteVM
            {
                PacienteVM = new PacienteVM
                {
                    Paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id)
                }
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult GetPadecimientos(int id)
        {
            var padecimientos = _unitOfWork.PadecimientosPacientes.GetAll(includeProperties: "Padecimiento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = padecimientos });
        }

        [HttpGet]
        public IActionResult ListaPadecimientos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

        [HttpGet]
        public IActionResult GetMedicamentos(int id)
        {
            var medicamentos = _unitOfWork.MedicamentosPacientes.GetAll(includeProperties: "Medicamento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = medicamentos });
        }

        [HttpGet]
        public IActionResult ListaMedicamentos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }


        [HttpGet]
        public IActionResult GetTratamientos(int id)
        {
            var tratamientos = _unitOfWork.TratamientosPacientes.GetAll(includeProperties: "Tratamiento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = tratamientos });
        }

        [HttpGet]
        public IActionResult ListaTratamientos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

        [HttpGet]
        public IActionResult ListaExamenesMedicos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

        [HttpGet]
        public IActionResult GetExamenes(int id)
        {
            var examenes = _unitOfWork.ExamenesPacientes
                              .GetAll(includeProperties: "MedicoTratante")
                              .Where(x => x.CedulaPaciente == id)
                              .Select(e => new {
                                  e.Id,
                                  e.Descripcion,
                                  ArchivoURL = Url.Content("~/" + e.ArchivoURL),
                                  MedicoTratante = e.MedicoTratante
                              });
            return Json(new { data = examenes });
        }

        [HttpGet]
        public IActionResult GetNotasMedicas(int id)
        {
            var notasMedicas = _unitOfWork.NotasMedicas.GetAll(includeProperties: "MedicoTratante")
                              .Where(x => x.CedulaPaciente == id).ToList();

            var notasMedicasFormateadas = notasMedicas.Select(n => new
            {
                n.Texto,
                Fecha = n.Fecha.ToString("yyyy-MM-dd HH:mm"),
                MedicoTratante = n.MedicoTratante
            });

            return Json(new { data = notasMedicasFormateadas });
        }


    }
}
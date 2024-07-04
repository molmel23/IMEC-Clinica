using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = Roles.Admin)]

    public class PacienteController : Controller
    {
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;

        private readonly UserManager<IdentityUser> _userManager;



        public PacienteController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;

        }

        public IActionResult Index()
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
        #endregion

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            PacienteVM myPaciente = new()
            {
                Paciente = new Paciente(),
                PacientesList = _unitOfWork.Pacientes.GetAll().Select(i => new SelectListItem
                {
                    Text = i.NombreCompleto,
                    Value = i.Cedula.ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                return View(myPaciente);
            }

            myPaciente.Paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id);
            if (myPaciente.Paciente == null)
            {
                return NotFound();
            }

            return View(myPaciente);
        }

        [HttpPost]
        public IActionResult Upsert(PacienteVM _pacienteVM)
        {
            if (ModelState.IsValid)
            {

                if (_pacienteVM.Paciente.Cedula == 0)
                {
                    _unitOfWork.Pacientes.Add(_pacienteVM.Paciente);
                }
                else
                {
                    _unitOfWork.Pacientes.Update(_pacienteVM.Paciente);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(_pacienteVM);
        }




        



        public IActionResult Delete(int? id)
        {
            var pacienteToDelete = _unitOfWork.Pacientes.Get(x => x.Cedula == id);



            if (pacienteToDelete != null)
            {
                var padecimientosPaciente = _unitOfWork.PadecimientosPacientes.GetAll().Where(x => x.CedulaPaciente == id).ToList();
                var tratamientosPaciente = _unitOfWork.TratamientosPacientes.GetAll().Where(x => x.CedulaPaciente == id).ToList();
                var medicamentosPaciente = _unitOfWork.MedicamentosPacientes.GetAll().Where(x => x.CedulaPaciente == id).ToList();
                var examenesPaciente = _unitOfWork.ExamenesPacientes.GetAll().Where(x => x.CedulaPaciente == id).ToList();
                var notasMedicas = _unitOfWork.NotasMedicas.GetAll().Where(x => x.CedulaPaciente == id).ToList();

                foreach (var padecimientoPaciente in padecimientosPaciente)
                {
                    _unitOfWork.PadecimientosPacientes.Remove(padecimientoPaciente);
                }

                foreach (var tratamientoPaciente in tratamientosPaciente)
                {
                    _unitOfWork.TratamientosPacientes.Remove(tratamientoPaciente);
                }

                foreach (var medicamentoPaciente in medicamentosPaciente)
                {
                    _unitOfWork.MedicamentosPacientes.Remove(medicamentoPaciente);
                }

                foreach (var examenPaciente in examenesPaciente)
                {
                    _unitOfWork.ExamenesPacientes.Remove(examenPaciente);
                }

                foreach (var notaMedica in notasMedicas)
                {
                    _unitOfWork.NotasMedicas.Remove(notaMedica);
                }

                _unitOfWork.Pacientes.Remove(pacienteToDelete);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Paciente borrado exitosamente" });
            }


            return Json(new { success = false, message = "Error al borrar el paciente" });

        }
    }
}


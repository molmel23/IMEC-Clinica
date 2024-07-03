using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public PacienteController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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

        #region HTTP_GET_Expediente
        [HttpGet]
        public IActionResult Expediente(int id)
        {
            ExpedienteVM model = new ExpedienteVM
            {
                PacienteVM = new PacienteVM
                {
                    Paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id)
                }
            };
            return View(model);
        }
        #endregion

        #region Padecimientos
        [HttpGet]
        public IActionResult GetPadecimientos(int id)
        {
            var padecimientos = _unitOfWork.PadecimientosPacientes.GetAll(includeProperties: "Padecimiento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = padecimientos });
        }

        [HttpGet]
        public IActionResult AgregarPadecimientos(int id)
        {
            ExpedienteVM model = new ExpedienteVM
            {
                PadecimientosPacientesVM = new PadecimientosPacientesVM
                {
                    PadecimientoPaciente = new Models.PadecimientosPacientes { CedulaPaciente = id }

                },
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                },
                PadecimientoVM = new PadecimientoVM
                {
                    PadecimientoList = _unitOfWork.Padecimiento.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Nombre,
                        Value = i.Id.ToString()
                    }).ToList()
                }
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarPadecimientos(ExpedienteVM model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PadecimientosPacientes.Add(model.PadecimientosPacientesVM.PadecimientoPaciente);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Padecimientos), new { id = model.PadecimientosPacientesVM.PadecimientoPaciente.CedulaPaciente });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Padecimientos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

        public IActionResult SuspenderPadecimiento(int? id)
        {
            var padecimientoToDelete = _unitOfWork.PadecimientosPacientes.Get(x => x.Id == id);

            if (padecimientoToDelete == null)
            {
                return Json(new { success = false, message = "Error al suspender" });
            }

            _unitOfWork.PadecimientosPacientes.Remove(padecimientoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Suspendido exitosamente" });
        }
        #endregion

        #region Medicamentos
        [HttpGet]
        public IActionResult GetMedicamentos(int id)
        {
            var medicamentos = _unitOfWork.MedicamentosPacientes.GetAll(includeProperties: "Medicamento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = medicamentos });
        }

        [HttpGet]
        public IActionResult AgregarMedicamentos(int id)
        {
            ExpedienteVM model = new ExpedienteVM
            {
                MedicamentosPacientesVM = new MedicamentosPacientesVM
                {
                    MedicamentosPacientes = new Models.MedicamentosPacientes { CedulaPaciente = id }

                },
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                },
                MedicamentoVM = new MedicamentoVM
                {
                    MedicamentoList = _unitOfWork.Medicamento.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Nombre,
                        Value = i.Id.ToString()
                    }).ToList()
                }
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarMedicamentos(ExpedienteVM model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MedicamentosPacientes.Add(model.MedicamentosPacientesVM.MedicamentosPacientes);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Medicamentos), new { id = model.MedicamentosPacientesVM.MedicamentosPacientes.CedulaPaciente });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Medicamentos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }


        public IActionResult SuspenderMedicamento(int? id)
        {
            var medicamentoToDelete = _unitOfWork.MedicamentosPacientes.Get(x => x.Id == id);

            if (medicamentoToDelete == null)
            {
                return Json(new { success = false, message = "Error al suspender" });
            }

            _unitOfWork.MedicamentosPacientes.Remove(medicamentoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Suspendido exitosamente" });
        }

        #endregion

        #region Tratamientos
        [HttpGet]
        public IActionResult GetTratamientos(int id)
        {
            var tratamientos = _unitOfWork.TratamientosPacientes.GetAll(includeProperties: "Tratamiento,MedicoTratante")
                                   .Where(x => x.CedulaPaciente == id);
            return Json(new { data = tratamientos });
        }

        [HttpGet]
        public IActionResult Tratamientos(int id)
        {
            ViewData["PacienteId"] = id;
            return View();
        }

        [HttpGet]
        public IActionResult AgregarTratamientos(int id)
        {
            ExpedienteVM model = new ExpedienteVM
            {
                TratamientosPacientesVM = new TratamientosPacientesVM
                {
                    TratamientosPacientes = new Models.TratamientosPacientes { CedulaPaciente = id }

                },
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                },
                TratamientoVM = new TratamientoVM
                {
                    TratamientoList = _unitOfWork.Tratamiento.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.Nombre,
                        Value = i.Id.ToString()
                    }).ToList()
                }
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarTratamientos(ExpedienteVM model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TratamientosPacientes.Add(model.TratamientosPacientesVM.TratamientosPacientes);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Tratamientos), new { id = model.TratamientosPacientesVM.TratamientosPacientes.CedulaPaciente });
            }

            return View(model);
        }

        public IActionResult SuspenderTratamiento(int? id)
        {
            var tratamientoToDelete = _unitOfWork.TratamientosPacientes.Get(x => x.Id == id);

            if (tratamientoToDelete == null)
            {
                return Json(new { success = false, message = "Error al suspender" });
            }

            _unitOfWork.TratamientosPacientes.Remove(tratamientoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Suspendido exitosamente" });
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
        #endregion

        #region ExamenesMedicos
        [HttpGet]
        public IActionResult ExamenesMedicos(int id)
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
        public IActionResult AgregarExamenesMedicos(int? id)
        {
            ExpedienteVM model = new ExpedienteVM
            {
                ExamenVM = new ExamenVM
                {
                    Examen = new Models.Examen { CedulaPaciente = id.Value }
                },
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AgregarExamenesMedicos(ExpedienteVM model, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                var uploads = Path.Combine(wwwRootPath, @"archivos\examenes");

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                model.ExamenVM.Examen.ArchivoURL = @"archivos\examenes\" + fileName + extension;
            }

            _unitOfWork.ExamenesPacientes.Add(model.ExamenVM.Examen);
            _unitOfWork.Save();
            return RedirectToAction("ExamenesMedicos", new { id = model.ExamenVM.Examen.CedulaPaciente });
        }
        #endregion
    }
}

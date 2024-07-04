using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Models;
using ProyectoProgramadoLenguajes2024.Utilities;
using Microsoft.DotNet.MSIdentity.Shared;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace ProyectoProgramadoLenguajes2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class ListaUsuariosController : Controller
    {
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public ListaUsuariosController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region GETs
        public IActionResult GetAll()
        {
            var pacientes = _unitOfWork.Pacientes.GetAll().Select(c => new
            {
                NombreCompleto = "|Paciente| "+c.NombreCompleto,
                Identificacion = c.Cedula
            }).ToList();

            return Json(new { data = pacientes});
        }

        public IActionResult Upsert(int? id)
        {
            if (id.HasValue)
            {
                // Determinar el tipo de objeto basado en el ID
                var paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id);
                var medicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id);
                var administrador = _unitOfWork.Administradores.Get(x => x.Cedula == id);

                if (paciente != null)
                {
                    // Lógica para upsert de Paciente
                    return View("UpsertPaciente", paciente);
                }
                else if (medicoTratante != null)
                {
                    // Lógica para upsert de Médico Tratante
                    return View("UpsertMedicoTratante", medicoTratante);
                }
                else if (administrador != null)
                {
                    // Lógica para upsert de Administrador
                    return View("UpsertAdministrador", administrador);
                }
                else
                {
                    // Objeto no encontrado, manejar según tu caso
                    return RedirectToAction("Index");
                }
            }
            else
            {
                // Lógica para crear nuevo objeto, si no se proporciona un ID
                return View("UpsertNuevo");
            }
        }

        #endregion

        #region HTTP_GET

        [HttpGet]
       public IActionResult GetUsuarios()
        {
            UsuariosVM usuariosVM = new UsuariosVM
            {
                PacienteVM = new PacienteVM
                {
                    PacientesList = _unitOfWork.Pacientes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.Cedula.ToString()
                    }).ToList()
                },
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                },
                AdministradorVM = new AdministradorVM
                {
                    AdministradorList = _unitOfWork.Administradores.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.Cedula.ToString()
                    }).ToList()
                }
            };

            return Json(new { data = usuariosVM });
        }


        #endregion

        #region HTTP_POST

        [HttpPost]
        
        public IActionResult AgregarPaciente(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pacientes.Add(paciente);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Paciente agregado exitosamente" });
            }
            return Json(new { success = false, message = "Error al agregar el paciente" });
        }

        [HttpPost]

        public IActionResult AgregarMedicoTratante(MedicoTratante medicoTratante)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MedicoTratantes.Add(medicoTratante);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Médico Tratante agregado exitosamente" });
            }
            return Json(new { success = false, message = "Error al agregar el médico tratante" });
        }

        [HttpPost]

        public IActionResult AgregarAdministrador(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Administradores.Add(administrador);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Administrador agregado exitosamente" });
            }
            return Json(new { success = false, message = "Error al agregar el administrador" });
        }



        #endregion

        #region API
      


       public IActionResult EliminarPaciente(int? id)
        {
            var paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id);
            if (paciente == null)
            {
                return Json(new { success = false, message = "Error al eliminar el paciente" });
            }
            _unitOfWork.Pacientes.Remove(paciente);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Paciente eliminado exitosamente" });
        }

        public IActionResult EliminarMedicoTratante(int? id)
        {
            var medicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id);
            if (medicoTratante == null)
            {
                return Json(new { success = false, message = "Error al eliminar el médico tratante" });
            }
            _unitOfWork.MedicoTratantes.Remove(medicoTratante);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Médico Tratante eliminado exitosamente" });
        }

        public IActionResult EliminarAdministrador(int? id)
        {
            var administrador = _unitOfWork.Administradores.Get(x => x.Cedula == id);
            if (administrador == null)
            {
                return Json(new { success = false, message = "Error al eliminar el administrador" });
            }
            _unitOfWork.Administradores.Remove(administrador);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Administrador eliminado exitosamente" });
        }


        public IActionResult Delete(int? id)
        {
            try
            {
                var paciente = _unitOfWork.Pacientes.Get(x => x.Cedula == id);
                var medicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id);
                var administrador = _unitOfWork.Administradores.Get(x => x.Cedula == id);

                if (paciente != null)
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

                    _unitOfWork.Pacientes.Remove(paciente);
                    _unitOfWork.Save();
                    return Json(new { success = true, message = "Paciente eliminado exitosamente" });
                }
                else if (medicoTratante != null)
                {
                    _unitOfWork.MedicoTratantes.Remove(medicoTratante);
                    _unitOfWork.Save();
                    return Json(new { success = true, message = "Médico Tratante eliminado exitosamente" });
                }
                else if (administrador != null)
                {
                    _unitOfWork.Administradores.Remove(administrador);
                    _unitOfWork.Save();
                    return Json(new { success = true, message = "Administrador eliminado exitosamente" });
                }
                else
                {
                    return Json(new { success = false, message = "No se encontró ningún registro con el ID proporcionado" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }


        #endregion

        [HttpPost]
        public async Task<IActionResult> BlockUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is null or empty.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            user.LockoutEnd = DateTimeOffset.UtcNow.AddYears(100); // Bloquea al usuario por 100 años
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ListaUsuarios");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction("Index", "ListaUsuarios");
        }

    }
}



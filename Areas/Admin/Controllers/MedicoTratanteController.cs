using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]

    public class MedicoTratanteController : Controller
    {

        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public string especialidad { get; set; }

        public MedicoTratanteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region HTTP_GET

        [HttpGet]
        public IActionResult Upsert(int? numeroColegiado)
        {
            MedicoTratanteVM myMedico = new()
            {
                MedicoTratante = new MedicoTratante(),
                MedicoTratenteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                {
                    Text = i.NombreCompleto,
                    Value = i.NumeroColegiado.ToString()
                }).ToList()
            };

            if (numeroColegiado == null || numeroColegiado == 0)
            {
                return View(myMedico);
            }

            myMedico.MedicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == numeroColegiado);
            if (myMedico.MedicoTratante == null)
            {
                return NotFound();
            }

            return View(myMedico);
        }


        #endregion

        #region HTTP_POST

        [HttpPost]
        public IActionResult Upsert(Especialidad_MedicoTratanteVM _especialidad_MedicoTratanteVM, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file.FileName);
                    var uploads = Path.Combine(wwwRootPath, @"images\vehicles");

                    if (_especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL != null)// Update
                    {
                        var oldImageUrl = Path.Combine(wwwRootPath, _especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL);

                        if (System.IO.File.Exists(oldImageUrl))
                            System.IO.File.Delete(oldImageUrl);
                    }


                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    _especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL = @"images\vehicles\" + fileName + extension;
                }

                if (_especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.NumeroColegiado == 0)
                    _unitOfWork.MedicoTratantes.Add(_especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante);
                else
                    _unitOfWork.MedicoTratantes.Update(_especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante);

                _unitOfWork.Save();

                addEspecialidad_MedicoTratante(_especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.NumeroColegiado, _especialidad_MedicoTratanteVM.MedicoTratanteVM.NombreEspecialidad);
                TempData["success"] = "Médico Tratante agregado exitosamente";

            }

            return RedirectToAction("Index");

        }

        public void addEspecialidad_MedicoTratante(int numeroColegiado, string especialidad)
        {
            Especialidad_MedicoTratante especialidadToAdd = new()
            {
                MedicoTratanteId = numeroColegiado,
                EspecialidadId = _unitOfWork.Especialidades.Get(x => x.Nombre == especialidad).Id
            };

            _unitOfWork.Especialidades_MedicoTratantes.Add(especialidadToAdd);
            _unitOfWork.Save();
        }

        #endregion

        #region API
        public IActionResult GetAll()
        {
            var medicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(c => new
            {
                c.NumeroColegiado,
                c.NombreCompleto,
                c.FotoURL
            });
            return Json(new { data = medicoTratanteList });

        }


        public IActionResult Delete(int? numeroColegiado)
        {
            var medicoTratanteToDelete = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == numeroColegiado);

            if (medicoTratanteToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar Médico Tratante" });
            }

            _unitOfWork.MedicoTratantes.Remove(medicoTratanteToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Médico Tratante borrado exitosamente" });
        }
        #endregion

    }
}

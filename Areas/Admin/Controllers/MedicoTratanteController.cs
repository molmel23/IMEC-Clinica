using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using ProyectoProgramadoLenguajes2024.Utilities;
using System.Collections;
using System.Linq;
using ProyectoProgramadoLenguajes2024.Data.Migrations;

namespace ProyectoProgramadoLenguajes2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]

    public class MedicoTratanteController : Controller
    {

        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;

        public MedicoTratanteController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        #endregion


        #region HTTP_GET

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Especialidad_MedicoTratanteVM myMedico = new Especialidad_MedicoTratanteVM
            {
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratante = new Models.MedicoTratante(),
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                },
                EspecialidadVM = new EspecialidadVM
                {
                    EspecialidadList = _unitOfWork.Especialidades.GetAll().Select(e => new SelectListItem
                    {
                        Text = e.Nombre,
                        Value = e.Id.ToString()
                    }).ToList()
                }
            };

            if (id != null && id != 0)
            {
                myMedico.MedicoTratanteVM.MedicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id);
                if (myMedico.MedicoTratanteVM.MedicoTratante == null)
                {
                    return NotFound();
                }
            }

            return View(myMedico);
        }

        #endregion


        #region HTTP_POST

        [HttpPost]
        public IActionResult Upsert(Especialidad_MedicoTratanteVM especialidad_MedicoTratanteVM, IFormFile? file)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                var uploads = Path.Combine(wwwRootPath, @"images\medicos");

                if (especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL != null)
                {
                    var oldImageUrl = Path.Combine(wwwRootPath, especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL);
                    if (System.IO.File.Exists(oldImageUrl))
                    {
                        System.IO.File.Delete(oldImageUrl);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL = @"images\medicos\" + fileName + extension;
            }
            else
            {
                if (especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.NumeroColegiado != 0)
                {
                    var existingMedico = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.NumeroColegiado);
                    if (existingMedico != null)
                    {
                        especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.FotoURL = existingMedico.FotoURL;
                    }
                }
            }

            var medicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.NumeroColegiado);

            if (medicoTratante == null)
            {
                _unitOfWork.MedicoTratantes.Add(especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante);
            }
            else
            {
                _unitOfWork.MedicoTratantes.Detach(medicoTratante);
                _unitOfWork.MedicoTratantes.Update(especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante);
            }

            _unitOfWork.Save();

            if (especialidad_MedicoTratanteVM.MedicoTratanteVM.Especialidad != 0)
            {
                addEspecialidad_MedicoTratante(especialidad_MedicoTratanteVM.MedicoTratanteVM.MedicoTratante.NumeroColegiado, especialidad_MedicoTratanteVM.MedicoTratanteVM.Especialidad);
            }
            TempData["success"] = "Médico Tratante agregado exitosamente";

            return RedirectToAction("Index");


        }

        public void addEspecialidad_MedicoTratante(int numeroColegiado, int especialidad)
        {
            Especialidad_MedicoTratante especialidadToAdd = new()
            {
                MedicoTratanteId = numeroColegiado,
                EspecialidadId = especialidad
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
                c.NombreCompleto
            });
            return Json(new { data = medicoTratanteList });

        }

        [HttpGet]
        public IActionResult Detalles(int? id)
        {
            Especialidad_MedicoTratanteVM myMedico = new Especialidad_MedicoTratanteVM
            {
                MedicoTratanteVM = new MedicoTratanteVM
                {
                    MedicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id),
                    MedicoTratanteList = _unitOfWork.MedicoTratantes.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.NombreCompleto,
                        Value = i.NumeroColegiado.ToString()
                    }).ToList()
                },
                EspecialidadVM = new EspecialidadVM
                {
                }
            };

            List<Especialidad_MedicoTratante> especialidadesMedico = _unitOfWork.Especialidades_MedicoTratantes.GetAll().Where(x => x.MedicoTratanteId == id).ToList();

            myMedico.EspecialidadVM = new EspecialidadVM
            {
                Especialidad = _unitOfWork.Especialidades.Get(x => x.Id == myMedico.MedicoTratanteVM.Especialidad),
                EspecialidadList = _unitOfWork.Especialidades.GetAll().Select(e => new SelectListItem
                {
                    Text = e.Nombre,
                    Value = e.Id.ToString()
                }).ToList()
            };

            myMedico.EspecialidadVM.EspecialidadList = myMedico.EspecialidadVM.EspecialidadList.Where(x => especialidadesMedico.Any(y => y.EspecialidadId == int.Parse(x.Value))).ToList();

            if (id != null && id != 0)
            {
                myMedico.MedicoTratanteVM.MedicoTratante = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id);
                if (myMedico.MedicoTratanteVM.MedicoTratante == null)
                {
                    return NotFound();
                }
            }

            return View(myMedico);
        }


        public IActionResult Delete(int? id)
        {

            var medicoTratanteToDelete = _unitOfWork.MedicoTratantes.Get(x => x.NumeroColegiado == id);

            if (medicoTratanteToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar Médico Tratante" });
            }

            var especialidadesMedico = _unitOfWork.Especialidades_MedicoTratantes.GetAll()
                .Where(x => x.MedicoTratanteId == id).ToList();

            foreach (var especialidadMedico in especialidadesMedico)
            {
                _unitOfWork.Especialidades_MedicoTratantes.Remove(especialidadMedico);
            }

            _unitOfWork.MedicoTratantes.Remove(medicoTratanteToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Médico Tratante borrado exitosamente" });
        }

        #endregion

    }
}
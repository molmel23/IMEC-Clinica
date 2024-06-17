using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;

namespace ProyectoProgramadoLenguajes2024.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EspecialidadControlador : Controller
    {
        private IUnitOfWork _unitOfWork;

        public EspecialidadControlador(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        
        public IActionResult Index()
        {
            return View();
        }


        #region HTTP_GET

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            EspecialidadVM myEspecialidad = new()
            {
                Especialidad = new Especialidad(),
                EspecialidadList = _unitOfWork.Especialidades.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.Id.ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                return View(myEspecialidad);
            }

            myEspecialidad.Especialidad = _unitOfWork.Especialidades.Get(x => x.Id == id);
            if (myEspecialidad.Especialidad == null)
            {
                return NotFound();
            }

            return View(myEspecialidad);
        }


        #endregion

        #region HTTP_POST

        [HttpPost]
        public IActionResult Upsert(EspecialidadVM _especialidadVM)
        {
            if (ModelState.IsValid)
            {

                if (_especialidadVM.Especialidad.Id == 0)
                    _unitOfWork.Especialidades.Add(_especialidadVM.Especialidad);
                else
                    _unitOfWork.Especialidades.Update(_especialidadVM.Especialidad);

                _unitOfWork.Save();
                TempData["success"] = "Especialidad agregada exitosamente";
                
            }
          
            return RedirectToAction("Index");

        }



        #endregion


        #region API


        public IActionResult GetAll()
        {
            var especialidadList = _unitOfWork.Especialidades.GetAll();
            return Json(new { data = especialidadList });

        }


        public IActionResult Delete(int? id)
        {
            var especialidadToDelete = _unitOfWork.Especialidades.Get(x => x.Id == id);

            if (especialidadToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar la especialidad" });
            }

            _unitOfWork.Especialidades.Remove(especialidadToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Especialidad borrada exitosamente" });
        }
        #endregion

    }
}

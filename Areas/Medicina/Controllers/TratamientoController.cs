using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Models;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Medicina.Controllers
{
    [Area("Medicina")]
    [Authorize(Roles = Roles.Medico)]
    public class TratamientoController : Controller
    {
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;

        public TratamientoController(IUnitOfWork unitOfWork)
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
        public IActionResult Upsert(int? id)
        {
            TratamientoVM myTratamiento = new()
            {
                Tratamiento = new Tratamiento(),
                TratamientoList = _unitOfWork.Tratamiento.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.Id.ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                return View(myTratamiento);
            }

            myTratamiento.Tratamiento = _unitOfWork.Tratamiento.Get(x => x.Id == id);
            if (myTratamiento.Tratamiento == null)
            {
                return NotFound();
            }

            return View(myTratamiento);
        }

        #endregion

        #region HTTP_POST

        [HttpPost]
        public IActionResult Upsert(TratamientoVM _tratamientoVM)
        {
            if (ModelState.IsValid)
            {

                if (_tratamientoVM.Tratamiento.Id == 0)
                    _unitOfWork.Tratamiento.Add(_tratamientoVM.Tratamiento);
                else
                    _unitOfWork.Tratamiento.Update(_tratamientoVM.Tratamiento);

                _unitOfWork.Save();
                TempData["success"] = "Tratamiento agregado exitosamente";

            }

            return RedirectToAction("Index");

        }
        #endregion

        #region API
        public IActionResult GetAll()
        {
            var tratamientoList = _unitOfWork.Tratamiento.GetAll().Select(c => new {
                c.Id,
                c.Nombre,
                c.Descripcion

            });
            return Json(new { data = tratamientoList });

        }


        public IActionResult Delete(int? id)
        {
            var tratamientoToDelete = _unitOfWork.Tratamiento.Get(x => x.Id == id);

            if (tratamientoToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar el tratamiento" });
            }

            _unitOfWork.Tratamiento.Remove(tratamientoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Tratamiento borrado exitosamente" });
        }
        #endregion
    }
}


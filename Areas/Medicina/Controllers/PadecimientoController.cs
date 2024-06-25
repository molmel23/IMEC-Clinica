using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoProgramadoLenguajes2024.Data.Repository.Interfaces;
using ProyectoProgramadoLenguajes2024.Models.ViewModels;
using ProyectoProgramadoLenguajes2024.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Medicina.Controllers
{
    [Area("Medicina")]
    [Authorize(Roles = Roles.Medico)]
    public class PadecimientoController : Controller
    {
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;

        public PadecimientoController(IUnitOfWork unitOfWork)
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
            PadecimientoVM myPadecimiento = new()
            {
                Padecimiento = new Padecimiento(),
                PadecimientoList = _unitOfWork.Padecimiento.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.Id.ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                return View(myPadecimiento);
            }

            myPadecimiento.Padecimiento = _unitOfWork.Padecimiento.Get(x => x.Id == id);
            if (myPadecimiento.Padecimiento == null)
            {
                return NotFound();
            }

            return View(myPadecimiento);
        }


        #endregion

        #region HTTP_POST

        [HttpPost]
        public IActionResult Upsert(PadecimientoVM _padecimientoVM)
        {
            if (ModelState.IsValid)
            {

                if (_padecimientoVM.Padecimiento.Id == 0)
                    _unitOfWork.Padecimiento.Add(_padecimientoVM.Padecimiento);
                else
                    _unitOfWork.Padecimiento.Update(_padecimientoVM.Padecimiento);

                _unitOfWork.Save();
                TempData["success"] = "Padecimiento agregado exitosamente";

            }

            return RedirectToAction("Index");

        }



        #endregion

        #region API
        public IActionResult GetAll()
        {
            var padecimientoList = _unitOfWork.Padecimiento.GetAll().Select(c => new {
                c.Id,
                c.Nombre,
                c.Descripcion

            });
            return Json(new { data = padecimientoList });

        }


        public IActionResult Delete(int? id)
        {
            var padecimientoToDelete = _unitOfWork.Padecimiento.Get(x => x.Id == id);

            if (padecimientoToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar el padecimiento" });
            }

            _unitOfWork.Padecimiento.Remove(padecimientoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Padecimiento borrada exitosamente" });
        }
        #endregion

    }
}

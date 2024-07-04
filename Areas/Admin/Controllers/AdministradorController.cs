using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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

    public class AdministradorController : Controller
    {
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;


        public AdministradorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetAll()
        {
            var administradoresList = _unitOfWork.Administradores.GetAll().Select(c => new
            {
                c.Cedula,
                c.NombreCompleto,
                c.CorreoElectronico
            });
            return Json(new { data = administradoresList });
        }
        #endregion

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            AdministradorVM myAdministrador = new()
            {
                Administrador = new Administrador(),
                AdministradorList = _unitOfWork.Administradores.GetAll().Select(i => new SelectListItem
                {
                    Text = i.NombreCompleto,
                    Value = i.Cedula.ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                return View(myAdministrador);
            }

            myAdministrador.Administrador = _unitOfWork.Administradores.Get(x => x.Cedula == id);
            if (myAdministrador.Administrador == null)
            {
                return NotFound();
            }

            return View(myAdministrador);
        }

        [HttpPost]
        public IActionResult Upsert(AdministradorVM _administradorVM)
        {
            if (ModelState.IsValid)
            {

                if (_administradorVM.Administrador.Cedula == 0)
                {
                    _unitOfWork.Administradores.Add(_administradorVM.Administrador);
                }
                else
                {
                    _unitOfWork.Administradores.Update(_administradorVM.Administrador);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(_administradorVM);
        }


        public IActionResult Delete(int? id)
        {
            var administradorToDelete = _unitOfWork.Administradores.Get(x => x.Cedula == id);

            if (administradorToDelete == null)
            {
                return Json(new { success = false, message = "Error borrando el administrador" });
            }
            else
            {
                _unitOfWork.Administradores.Remove(administradorToDelete);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Administrador borrado exitosamente" });
            }

        }


    }
}


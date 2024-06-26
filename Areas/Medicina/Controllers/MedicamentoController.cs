using Microsoft.AspNetCore.Authorization;
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
    public class MedicamentoController: Controller
    {
        #region Properties_Constructor
        private IUnitOfWork _unitOfWork;

        public MedicamentoController(IUnitOfWork unitOfWork)
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
            MedicamentoVM myMedicamento = new()
            {
                Medicamento = new Medicamento(),
                MedicamentoList = _unitOfWork.Medicamento.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Nombre,
                    Value = i.Id.ToString()
                }).ToList()
            };

            if (id == null || id == 0)
            {
                return View(myMedicamento);
            }

            myMedicamento.Medicamento = _unitOfWork.Medicamento.Get(x => x.Id == id);
            if (myMedicamento.Medicamento == null)
            {
                return NotFound();
            }

            return View(myMedicamento);
        }
        #endregion
        #region HTTP_POST

        [HttpPost]
        public IActionResult Upsert(MedicamentoVM _medicamentoVM)
        {
            if (ModelState.IsValid)
            {

                if (_medicamentoVM.Medicamento.Id == 0)
                    _unitOfWork.Medicamento.Add(_medicamentoVM.Medicamento);
                else
                    _unitOfWork.Medicamento.Update(_medicamentoVM.Medicamento);

                _unitOfWork.Save();
                TempData["success"] = "Medicamento agregado exitosamente";

            }

            return RedirectToAction("Index");
        }
        #endregion

        #region API
        public IActionResult GetAll()
        {
            var medicamentoList = _unitOfWork.Medicamento.GetAll().Select(c => new {
                c.Id,
                c.Nombre

            });
            return Json(new { data = medicamentoList });

        }


        public IActionResult Delete(int? id)
        {
            var medicamentoToDelete = _unitOfWork.Medicamento.Get(x => x.Id == id);

            if (medicamentoToDelete == null)
            {
                return Json(new { success = false, message = "Error al borrar el medicamento" });
            }

            _unitOfWork.Medicamento.Remove(medicamentoToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Medicamento borrado exitosamente" });
        }
        #endregion
    }
}

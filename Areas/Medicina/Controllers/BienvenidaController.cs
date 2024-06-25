using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramadoLenguajes2024.Utilities;

namespace ProyectoProgramadoLenguajes2024.Areas.Medicina.Controllers
{
    [Area("Medicina")]
    [Authorize(Roles = Roles.Medico)]
    public class BienvenidaController : Controller
    {
   
        public ActionResult Index()
        {
            return View();
        }


    }
}

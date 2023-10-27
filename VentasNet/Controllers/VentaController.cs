using Microsoft.AspNetCore.Mvc;

namespace VentasNet.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Venta()
        {
            return View();
        }
    }
}

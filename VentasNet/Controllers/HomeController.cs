using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VentasNet.Infra.DTO.Common;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(UsuarioReq usuario)
        {
            if (usuario != null)
            {
                usuario.login = ObjPersistido.Usuario.login;
            }
            return View(usuario);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult actionResult()
        {
            return View();
        }
    }
}
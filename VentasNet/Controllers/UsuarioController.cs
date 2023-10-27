using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using VentasNet.Infra.DTO.Common;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace VentasNet.Controllers
{
    public class UsuarioController : Controller
    {
        //UsuarioRepo usuarioRepo = new UsuarioRepo();
        IUsuarioRepo usuarioRepo;

        public UsuarioController(IUsuarioRepo _usuarioRepo)
        {
            usuarioRepo = _usuarioRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Inicio(UsuarioReq usuario)
        {
            return View(usuario);
        }
        public IActionResult Autenticacion(UsuarioReq usuario)
        {
            //Usuario objUsuario = new Usuario() { Email = "simon@gmail.com", Password = "1234" };
            //if (objUsuario.Email == usuario.Email && objUsuario.Password == usuario.Password)
            //    return RedirectToAction("usuario");

            //return RedirectToAction("Inicio");
            bool habilitado = usuarioRepo.PermisoUsuario(usuario);
            
            if (habilitado)
                return RedirectToAction("usuario");
            else
            {
                usuario.login = false;
                ObjPersistido.Usuario.login = false;
                return RedirectToAction("Index","Home", usuario);
            }

            
        }

        public IActionResult Usuario()
        {
            return View();
        }
    }
}

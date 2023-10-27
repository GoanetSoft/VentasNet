using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace VentasNet.Controllers
{
    public class ProveedorController : Controller
    {
        IProveedorRepo proveedorRepo;

        public ProveedorController(IProveedorRepo _proveedorRepo)
        {
            proveedorRepo = _proveedorRepo;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {


            ViewBag.Proveedor = proveedorRepo.GetProveedor();

            return View();
        }

        public IActionResult GuardarProveedor(ProveedorReq prov)
        {
            
            var result = proveedorRepo.AgregarProveedor(prov);

            return RedirectToAction("Listado");
        }



        public IActionResult AgregarProveedor(ProveedorReq prov)
        {

            return View();
        }

        public IActionResult Edit(ProveedorReq prov)
        {
            
            var provedorResponse = proveedorRepo.UpdateProveedor(prov);


            return RedirectToAction("Listado", prov);
        }

        public IActionResult Modificar(ProveedorReq prov)
        {



            return View(prov);
        }

        public IActionResult Delete(ProveedorReq prov)
        {
          
            var proveedorResponse = proveedorRepo.DeleteProveedor(prov);


            return RedirectToAction("Listado");
        }
    }
}

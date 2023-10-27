using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {
       
        private readonly IClienteRepo _clienteRepo;
        public ClienteController(IClienteRepo clienteRepo)
        {           
            _clienteRepo = clienteRepo;            
        }

        public IActionResult AgregarCliente(ClienteReq cli)
        {
            return View();
        }
        public IActionResult Modificar(ClienteReq cli)
        {
            return View(cli);
        }

        public IActionResult UpdateCliente(ClienteReq cli)
        {
            var clienteResponse = _clienteRepo.UpdateCliente(cli);

            return RedirectToAction("Listado", cli);
        }

        public IActionResult Delete(ClienteReq cli)
        {
            var clienteResponse = _clienteRepo.DeleteCliente(cli);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarCliente(ClienteReq cli)
        {
            var result = _clienteRepo.AgregarCliente(cli);

            return RedirectToAction("Listado");
        }

        public IActionResult Listado()
        {
            ViewBag.Cliente = _clienteRepo.GetClientes();
            return View();
        }
    }

    
}

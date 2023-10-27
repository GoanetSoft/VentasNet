using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repositories;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Controllers
{
    public class ProductoController : Controller
    {
        //ProductoRepo productoRepo = new ProductoRepo();

        IProductoRepo productoRepo;

        public ProductoController(IProductoRepo _productoRepo)
        {
            productoRepo = _productoRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {


            //ViewBag.Producto = ListadosReq.ListaProducto.Where(x =>
            //{
            //    return x.Estado == true;
            //});
            ViewBag.Producto = productoRepo.GetProducto();

            return View();
        }

        public IActionResult GuardarProducto(ProductoReq prod)
        {
            //bool existe = false;

            //existe = productoRepo.VerificarProducto(prod);
            //if (existe)
            //{
            //    productoRepo.ModificarProducto(prod);
            //}
            //else
            //{
            //    prod.Estado = true;
            //    ListadosReq.ListaProducto.Add(prod);
            //}

            var result = productoRepo.AgregarProducto(prod);

            return RedirectToAction("Listado");
        }



        public IActionResult AgregarProducto(ProductoReq prod)
        {

            return View();
        }

        public IActionResult Edit(ProductoReq prod)
        {
            //ProductoReq prod = new ProductoReq();

            //prod = ListadosReq.ListaProducto.Find(x => x.Id == id);

            //return RedirectToAction("AgregarProducto", prod);

            var productoResponse = productoRepo.UpdateProducto(prod);


            return RedirectToAction("Listado", prod);
        }

        public IActionResult Modificar(ProductoReq prod)
        {
            
            //var producto = productoRepo.GetProductoNombre(prod.NombreProducto);
            

            return View(prod);
        }

        public IActionResult Delete(ProductoReq prod)
        {
            //    ProductoReq prod = new ProductoReq();

            //    prod = ListadosReq.ListaProducto.Find(x => x.Id == id);

            //    productoRepo.DeleteProducto(prod);
            var productoResponse = productoRepo.DeleteProducto(prod);


            return RedirectToAction("Listado");
        }
    }
}

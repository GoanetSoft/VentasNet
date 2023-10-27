using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Services.Mapeo;

namespace VentasNet.Infra.Repositories
{
    public class ProductoRepo : IProductoRepo
    {
        private readonly VentasNetContext _context;

        public ProductoRepo(VentasNetContext context)
        {
            _context = context;
        }

        public ProductoResponse AgregarProducto(ProductoReq objProducto)
        {

            ProductoResponse productoResponse = new ProductoResponse();
            var existeProducto = GetProductoNombre(objProducto.NombreProducto);

            if (existeProducto == null)
            {
                try
                {
                    var productoNew = MapeoProducto(objProducto);
                    productoNew.Estado = true;
                    //productoNew.FechaAlta = DateTime.Now.Date;

                    _context.Add(productoNew);
                    _context.SaveChanges();
                    productoResponse.Guardar = true;
                    productoResponse.NombreProducto = productoNew.NombreProducto;
                }
                catch (DbUpdateException ex)
                {
                    // Manejar errores específicos de Entity Framework aquí
                    productoResponse.Mensaje = "Error al guardar en la base de datos: " + ex.Message;
                    productoResponse.Guardar = false;
                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Ocurrio un error al Agregar producto";
                    productoResponse.Guardar = false;
                }

            }
            return productoResponse;
        }

        public ProductoResponse UpdateProducto(ProductoReq objProducto)
        {
            ProductoResponse productoResponse = new ProductoResponse();
            var existeProducto = GetProductoNombre(objProducto.NombreProducto);

            if (existeProducto != null)
            {
                try
                {
                    existeProducto = ValidarProducto(objProducto, existeProducto);

                    _context.Update(existeProducto);
                    _context.SaveChanges();
                    productoResponse.Guardar = true;
                    productoResponse.NombreProducto = existeProducto.NombreProducto;
                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Ocurrio un error al Modificar Producto";
                    productoResponse.Guardar = false;
                }

            }
            return productoResponse;
        }

        public ProductoResponse DeleteProducto(ProductoReq objProducto)
        {

            ProductoResponse productoResponse = new ProductoResponse();
            var existeProducto = GetProductoNombre(objProducto.NombreProducto);
            if (existeProducto != null)
            {
                try
                {
                    existeProducto.Estado = false;
                    //existeProducto.FechaBaja = DateTime.Now;

                    _context.Update(existeProducto);
                    _context.SaveChanges();
                    productoResponse.Guardar = true;
                    productoResponse.NombreProducto = existeProducto.NombreProducto;
                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Ocurrio un error al Eliminar un Producto";
                    productoResponse.Guardar = false;
                }

            }
            return productoResponse;

        }

        public Producto GetProductoNombre(string Nombre)
        {
            var producto = _context.Producto.Where(x => x.NombreProducto == Nombre).FirstOrDefault();

            return producto;
        }

        public Producto MapeoProducto(ProductoReq objProducto)
        {
            Producto producto = objProducto.ToModel();          

            return producto;
        }

        public Producto ValidarProducto(ProductoReq obj, Producto existeProducto)
        {

            existeProducto.NombreProducto = obj.NombreProducto != null ? obj.NombreProducto : existeProducto.NombreProducto;
            existeProducto.Descripcion = obj.Descripcion != null ? obj.Descripcion : existeProducto.Descripcion;
            existeProducto.ImporteProducto = obj.ImporteProducto != null ? obj.ImporteProducto : existeProducto.ImporteProducto;
            


            return existeProducto;
        }

        public List<ProductoReq> GetProducto()
        {
            List<ProductoReq> listadoProducto = new List<ProductoReq>();

            var lista = _context.Producto.Where(x => x.Estado != false).ToList();

            foreach (var item in lista)
            {
                ProductoReq productoReq = new ProductoReq();
                productoReq.IdProducto = item.IdProducto;
                productoReq.NombreProducto = item.NombreProducto;
                productoReq.Descripcion = item.Descripcion;
                productoReq.ImporteProducto = item.ImporteProducto;
                productoReq.Estado = item.Estado;

                listadoProducto.Add(productoReq);
            }

            return listadoProducto;
        }

        public void ModificarProducto(ProductoReq prod)
        {

            var index = ListadosReq.ListaProducto.FindIndex(x => x.NombreProducto == prod.NombreProducto);

            if (index != -1)
            {

                ListadosReq.ListaProducto[index].NombreProducto = prod.NombreProducto;
                ListadosReq.ListaProducto[index].Descripcion = prod.Descripcion;
                ListadosReq.ListaProducto[index].ImporteProducto = prod.ImporteProducto;


            }


        }

    }
}

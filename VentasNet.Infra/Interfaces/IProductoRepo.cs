using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IProductoRepo
    {
        
        public ProductoResponse AgregarProducto(ProductoReq objProducto);
        public ProductoResponse UpdateProducto(ProductoReq objProducto);
        public ProductoResponse DeleteProducto(ProductoReq objProducto);
        public Producto GetProductoNombre(string Nombre);
        public Producto MapeoProducto(ProductoReq objProducto);
        public List<ProductoReq> GetProducto();
        public void ModificarProducto(ProductoReq prov);

    }
}

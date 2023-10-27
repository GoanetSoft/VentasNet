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
    public interface IProveedorRepo
    {
        
        public ProveedorResponse AgregarProveedor(ProveedorReq objProveedor);
        public ProveedorResponse UpdateProveedor(ProveedorReq objProveedor);
        public ProveedorResponse DeleteProveedor(ProveedorReq objProveedor);
        public Proveedor GetProveedorCuit(string Cuit);
        public Proveedor MapeoProveedor(ProveedorReq objProveedor);
        public List<ProveedorReq> GetProveedor();
        public void ModificarProveedor(ProveedorReq prov);
    }
}

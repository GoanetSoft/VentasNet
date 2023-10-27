using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using System.Data;

namespace VentasNet.Infra.Repositories
{
    public class ProveedorRepo : IProveedorRepo
    {
        //public ProveedorRepo() { } //Constructor - Es el mismo nombre de la clase

        private readonly VentasNetContext _context;

        public ProveedorRepo(VentasNetContext context)
        {
            _context = context;
        }

        public ProveedorResponse AgregarProveedor(ProveedorReq objProveedor)
        {

            ProveedorResponse proveedorResponse = new ProveedorResponse();
            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor == null)
            {
                try
                {
                    var proveedorNew = MapeoProveedor(objProveedor);
                    proveedorNew.Estado = true;
                    //proveedorNew.FechaAlta = DateTime.Now.Date;

                    _context.Add(proveedorNew);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = proveedorNew.RazonSocial;
                }
                catch (DbUpdateException ex)
                {
                    // Manejar errores específicos de Entity Framework aquí
                    proveedorResponse.Mensaje = "Error al guardar en la base de datos: " + ex.Message;
                    proveedorResponse.Guardar = false;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrio un error al Agregar proveedor";
                    proveedorResponse.Guardar = false;
                }

            }
            return proveedorResponse;
        }

        public ProveedorResponse UpdateProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();
            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor = ValidarProveedor(objProveedor, existeProveedor);

                    _context.Update(existeProveedor);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = existeProveedor.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrio un error al Modificar Cliente";
                    proveedorResponse.Guardar = false;
                }

            }
            return proveedorResponse;
        }

        public ProveedorResponse DeleteProveedor(ProveedorReq objProveedor)
        {

            ProveedorResponse proveedorResponse = new ProveedorResponse();
            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);
            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor.Estado = false;
                    //existeProveedor.FechaBaja = DateTime.Now;

                    _context.Update(existeProveedor);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = existeProveedor.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrio un error al Eliminar un Cliente";
                    proveedorResponse.Guardar = false;
                }

            }
            return proveedorResponse;

        }

        public Proveedor GetProveedorCuit(string Cuit)
        {
            var proveedor = _context.Proveedor.Where(x => x.Cuit == Cuit).FirstOrDefault();

            return proveedor;
        }

        public Proveedor MapeoProveedor(ProveedorReq objProveedor)
        {
            Proveedor proveedor = new Proveedor
            {
                IdProveedor = objProveedor.IdProveedor,
                RazonSocial = objProveedor.RazonSocial,
                Cuit = objProveedor.Cuit,
                Domicilio = objProveedor.Domicilio != null ? objProveedor.Domicilio : string.Empty,
                Provincia = objProveedor.Provincia != null ? objProveedor.Provincia : string.Empty,
                Estado = objProveedor.Estado,
            };

            return proveedor;
        }

        public Proveedor ValidarProveedor(ProveedorReq obj, Proveedor existeProveedor)
        {

            existeProveedor.RazonSocial = obj.RazonSocial != null ? obj.RazonSocial : existeProveedor.RazonSocial;
            existeProveedor.Cuit = obj.Cuit != null ? obj.Cuit : existeProveedor.Cuit;
            existeProveedor.Domicilio = obj.Domicilio != null ? obj.Domicilio : existeProveedor.Domicilio;
            existeProveedor.Provincia = obj.Provincia != null ? obj.Provincia : existeProveedor.Provincia;


            return existeProveedor;
        }

        public List<ProveedorReq> GetProveedor()
        {
            List<ProveedorReq> listadoProveedor = new List<ProveedorReq>();

            var lista = _context.Proveedor.Where(x => x.Estado != false).ToList();

            foreach (var item in lista)
            {
                ProveedorReq proveedorReq = new ProveedorReq();
                proveedorReq.IdProveedor = item.IdProveedor;
                proveedorReq.Cuit = item.Cuit;
                proveedorReq.RazonSocial = item.RazonSocial;
                proveedorReq.Domicilio = item.Domicilio;
                proveedorReq.Provincia = item.Provincia;
                proveedorReq.Estado = item.Estado;

                listadoProveedor.Add(proveedorReq);
            }

            return listadoProveedor;
        }

        public void ModificarProveedor(ProveedorReq prov)
        {

            var index = ListadosReq.ListaProveedor.FindIndex(x => x.Cuit == prov.Cuit);

            if (index != -1)
            {

                ListadosReq.ListaProveedor[index].RazonSocial = prov.RazonSocial;
                ListadosReq.ListaProveedor[index].Cuit = prov.Cuit;
                ListadosReq.ListaProveedor[index].Domicilio = prov.Domicilio;
                ListadosReq.ListaProveedor[index].Provincia = prov.Provincia;


            }

            
        }

        
    }
}

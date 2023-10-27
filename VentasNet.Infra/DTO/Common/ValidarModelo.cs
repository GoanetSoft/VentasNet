using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.DTO.Common
{
    public static class ValidarModelo
    {
        public static Cliente ValidarCliente(ClienteReq obj, Cliente existeCliente)
        {

            existeCliente.RazonSocial = obj.RazonSocial != null ? obj.RazonSocial : existeCliente.RazonSocial;
            existeCliente.Cuil = obj.Cuil != null ? obj.Cuil : existeCliente.Cuil;
            existeCliente.Nombre = obj.Nombre != null ? obj.Nombre : existeCliente.Nombre;
            existeCliente.Apellido = obj.Apellido != null ? obj.Apellido : existeCliente.Apellido;
            existeCliente.Domicilio = obj.Domicilio != null ? obj.Domicilio : existeCliente.Domicilio;
            existeCliente.Localidad = obj.Localidad != null ? obj.Localidad : existeCliente.Localidad;
            existeCliente.Provincia = obj.Provincia != null ? obj.Provincia : existeCliente.Provincia;
            existeCliente.Telefono = obj.Telefono != null ? obj.Telefono : existeCliente.Telefono;


            return existeCliente;
        }

    }
}

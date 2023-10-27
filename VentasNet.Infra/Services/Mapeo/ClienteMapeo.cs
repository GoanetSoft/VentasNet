using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ClienteMapeo
    {

        public static Cliente ReqAModelo(ClienteReq objCliente)
        {

            Cliente cliente = new Cliente
            {
                IdCliente = objCliente.IdCliente,
                RazonSocial = objCliente.RazonSocial,
                Cuil = objCliente.Cuil,
                Nombre = objCliente.Nombre,
                Apellido = objCliente.Apellido,
                Domicilio = objCliente.Domicilio != null ? objCliente.Domicilio : string.Empty,
                Localidad = objCliente.Localidad != null ? objCliente.Localidad : string.Empty,
                Provincia = objCliente.Provincia != null ? objCliente.Provincia : string.Empty,
                Telefono = objCliente.Telefono != null ? objCliente.Telefono : string.Empty,
                Estado = objCliente.Estado,
                FechaAlta = objCliente.FechaAlta,
                FechaBaja = objCliente.FechaBaja,
                IdUsuario = objCliente.IdUsuario,
            };

            return cliente;
        }
    }
}

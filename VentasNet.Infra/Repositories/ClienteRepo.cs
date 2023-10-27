using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using ServicesCrud;
using VentasNet.Infra.Services.Interfaces;
using VentasNet.Infra.Services.Mapeo;
using VentasNet.Infra.DTO.Common;

namespace VentasNet.Infra.Repositories
{
    public class ClienteRepo : IClienteRepo //Invocamos a nuestra interface (no es lo mismo que heredar) Es como un contrato todo lo que esta en interface debo poner
    {
        private readonly VentasNetContext _context;
        private readonly IClienteService _clienteService; 
        

        public ClienteRepo(VentasNetContext context, IClienteService clienteService) 
        {
            _context = context;
            _clienteService = clienteService;
        } //Constructor - Es el mismo nombre de la clase

        public ClienteResponse AgregarCliente(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuil);
            
            if (existeCliente == null)
            {
                try
                {
                    var clienteNew = ClienteMapeo.ReqAModelo(objCliente);
                    clienteNew.Estado = true;
                    clienteNew.FechaAlta = DateTime.Now.Date;
                    _clienteService.CrearNuevoCliente(clienteNew);

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = clienteNew.RazonSocial;

                }
                catch (DbUpdateException ex)
                {
                    // Manejar errores específicos de Entity Framework aquí

                    //crear un Diccionario de Mensajes
                    clienteResponse.Mensaje = "Error al guardar en la base de datos: " + ex.Message;
                    clienteResponse.Guardar = false;
                }
                catch (Exception ex) 
                {
                    clienteResponse.Mensaje = "Ocurrio un error al Agregar Cliente";
                    clienteResponse.Guardar = false;
                }

            }
            return clienteResponse;
        }

        public ClienteResponse UpdateCliente(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();
            var existeCliente = GetClienteCuit(objCliente.Cuil);

            if (existeCliente != null)
            {
                try
                {
                     var cliente = ValidarModelo.ValidarCliente(objCliente, existeCliente);

                    _clienteService.ModificarCliente(cliente);

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrio un error al Modificar Cliente";
                    clienteResponse.Guardar = false;
                }

            }
            return clienteResponse;
        }

        public ClienteResponse DeleteCliente(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();
            var existeCliente = GetClienteCuit(objCliente.Cuil);
            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Estado = false;
                    existeCliente.FechaBaja = DateTime.Now;

                    _clienteService.EliminarCliente(existeCliente.IdCliente);

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrio un error al Eliminar un Cliente";
                    clienteResponse.Guardar = false;
                }

            }
            return clienteResponse;

        }

        public Cliente GetClienteCuit(string Cuil)
        {
            var cliente = _context.Cliente.Where(x => x.Cuil == Cuil).FirstOrDefault();

            return cliente;
        }

        
        public List<ClienteReq> GetClientes()
        {
            List<ClienteReq> listadoClientes = new List<ClienteReq>();

            var lista = _context.Cliente.Where(x => x.Estado != false).ToList();           

            foreach ( var item in lista ) 
            {
                ClienteReq clienteReq = new ClienteReq();
                clienteReq.IdCliente = item.IdCliente;
                clienteReq.Apellido = item.Apellido;
                clienteReq.Nombre = item.Nombre;
                clienteReq.Cuil = item.Cuil;
                clienteReq.RazonSocial = item.RazonSocial;
                clienteReq.Domicilio = item.Domicilio;
                clienteReq.Provincia = item.Provincia;
                clienteReq.Estado = item.Estado;
                clienteReq.FechaAlta = item.FechaAlta;
                clienteReq.FechaBaja = item.FechaBaja;

                listadoClientes.Add(clienteReq);
            }

            return listadoClientes;
        }

        public void ModificarCliente(ClienteReq cli)
        {
            
            var index = ListadosReq.ListaCliente.FindIndex(x => x.Cuil == cli.Cuil);

            if (index != -1)
            {
                
                ListadosReq.ListaCliente[index].RazonSocial = cli.RazonSocial;
                ListadosReq.ListaCliente[index].Cuil = cli.Cuil;
                ListadosReq.ListaCliente[index].Domicilio = cli.Domicilio;
                ListadosReq.ListaCliente[index].Provincia = cli.Provincia;
                

            }

            //debe buscar cual es el elemento y pasar cual deben ser los elementos
            //existeCliente = Listados.ListaCliente.Find(x => x.Id == cli.Id);
            //if (existeCliente != null)
            //{
            //    Listados.ListaCliente.Where(x => x.Id == existeCliente.Id)


            //}
        }

        public bool VerificarCliente(ClienteReq cli)
        {
            
            bool existe = false;
            ClienteReq existeCliente = new ClienteReq();

            existeCliente = ListadosReq.ListaCliente.Find(x => x.Cuil == cli.Cuil);

            if (existeCliente != null)
            {
                existe = true;
            }

            return existe;

        }


    }
}

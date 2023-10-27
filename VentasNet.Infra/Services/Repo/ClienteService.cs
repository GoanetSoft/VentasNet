using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Services.Interfaces;

namespace VentasNet.Infra.Services.Repo
{
    public class ClienteService : IClienteService
    {
        private readonly VentasNetContext _context;

        public ClienteService(VentasNetContext context)
        {
            _context = context;
        }

        public void CrearNuevoCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }
        public void ModificarCliente(Cliente cliente)
        {
            var cli = _context.Cliente.Where(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();
            //Mapeo con automapper
            if (cliente != null)
            {
                cliente.Estado = false;
                cliente.FechaBaja = DateTime.Now;
                _context.Update(cliente);
                _context.SaveChanges();
            }
        }
        public void EliminarCliente(int id)
        {
            var cliente = _context.Cliente.Where(x => x.IdCliente == id && x.Estado==true).FirstOrDefault();

            if (cliente != null)
            {
                cliente.Estado = false;
                cliente.FechaBaja = DateTime.Now;
                _context.Update(cliente);
                _context.SaveChanges();
            }
        }


    }
}

using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Repositories
{
    public class VentaRepo
    {
        private readonly VentasNetContext _context;

        public VentaRepo(VentasNetContext context)
        {
            _context = context;

        }

        public int? GetUltimoComprobante(string tipoFactura)
        {
            int? nroCbte =null;
            var comprobante = _context.VwComprobantes.Where(x => x.NombreCorto == tipoFactura).FirstOrDefault();

            if (comprobante != null)
            {
                nroCbte = comprobante.NroUltimoCbte;
            }

            return nroCbte;
        }

        public int? GetProximoComprobante(string tipoFactura)
        {
            int? nroCbte = null;
            var comprobante = _context.VwComprobantes.Where(x => x.NombreCorto == tipoFactura).FirstOrDefault();

            if (comprobante != null)
            {
                nroCbte = comprobante.NroUltimoCbte + 1;
            }

            return nroCbte;
        }

        public int? GetSucursal(string tipoFactura)
        {
            int? nroCbte = null;
            var comprobante = _context.VwComprobantes.Where(x => x.NombreCorto == tipoFactura).FirstOrDefault();

            if (comprobante != null)
            {
                nroCbte = comprobante.NroUltimoCbte + 1;
            }

            return nroCbte;
        }
    }
}

using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.Repositories
{
    public class VentaRepo
    {
        private VentaReq _venta = new VentaReq();
        public VentaRepo() { }

        public VentaReq VentaMostrador()
        {
            return _venta;
           
        }
    }
}



namespace VentasNet.Infra.DTO.Request
{
    public class VentaReq : ClienteReq
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public double Total { get; set; }
        
    }
}

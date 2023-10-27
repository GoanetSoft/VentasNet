namespace VentasNet.Infra.DTO.Request
{
    public class ProductoVendidoReq
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set;}
        public int Cantidad { get; set;}
    }
}

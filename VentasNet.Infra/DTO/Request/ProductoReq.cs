namespace VentasNet.Infra.DTO.Request
{
    public class ProductoReq
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public double? ImporteProducto { get; set; }

        public bool Estado { get; set; }

    }
}

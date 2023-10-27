namespace VentasNet.Infra.DTO.Request
{
    public class ProveedorReq
    {
        public int IdProveedor { get; set; }
        public string? RazonSocial { get; set; }
        public string? Cuit { get; set; }
        public string? Domicilio { get; set; }
        public string? Provincia { get; set; }
        public bool Estado { get; set; }
    }
}

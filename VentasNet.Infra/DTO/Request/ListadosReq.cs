namespace VentasNet.Infra.DTO.Request
{
    public static class ListadosReq
    {
        public static List<ClienteReq> ListaCliente { get; set; } = new List<ClienteReq>(); //le digo que si esto llega ser vacio hacer el new
        
        public static List<ProveedorReq> ListaProveedor { get; set; } = new List<ProveedorReq>();

        public static List<ProductoReq> ListaProducto { get; set;} = new List<ProductoReq>();

        public static List<ProductoVendidoReq> ListaProductoVendido { get; set; } = new List<ProductoVendidoReq>();

        public static List<VentaReq> ListaVentas { get; set; } = new List<VentaReq>();

        public static List<UsuarioReq> ListaUsuarios { get; set; } = new List<UsuarioReq>(); 
        //{ new UsuarioReq { Id = 0, Email = "simon@gmail.com", Password = "1234" } };
    }
}

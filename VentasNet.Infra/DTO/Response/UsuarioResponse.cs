using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Common;

namespace VentasNet.Infra.DTO.Response
{
    public class UsuarioResponse : Mensajes
    {
        public string UserName { get; set; }
        public bool Guardar { get; set; } = false;
        public bool Logueado { get; set; } = false;
    }
}

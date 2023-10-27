using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;

namespace VentasNet.Infra.DTO.Common
{
    public class ObjPersistido
    {
        public static UsuarioReq Usuario { get; set; } = new UsuarioReq();
    }
}

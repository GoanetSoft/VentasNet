using Microsoft.EntityFrameworkCore;
using VentasNet.Entity.Data;
using VentasNet.Infra.DTO.Common;
using VentasNet.Infra.DTO.Request;
using VentasNet.Entity.Models;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Repositories
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly VentasNetContext _context;

        public UsuarioRepo(VentasNetContext context)
        {
            _context = context;
        }


        public bool PermisoUsuario(UsuarioReq usu)
        {
            bool habilitado = false;
            //UsuarioReq usuarioRegistrado = new UsuarioReq();

             var usuarioRegistrado = _context.Usuario.Where(x => x.Email == usu.Email && x.Password == usu.Password).FirstOrDefault(); //Busca el primer usuario compatible

            if (usuarioRegistrado != null)
            {
                habilitado = true;
                ObjPersistido.Usuario.login = true;
                UsuarioPersistir(usuarioRegistrado);
            }

            return habilitado;

        }

        
        public void UsuarioPersistir(Usuario usuario)
        {
            ObjPersistido.Usuario.UserName = usuario.UserName;
            ObjPersistido.Usuario.IdTipoUsuario = usuario.IdTipoUsuario;

        }
    }
}

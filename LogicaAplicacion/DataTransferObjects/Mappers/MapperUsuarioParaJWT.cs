using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperUsuarioParaJWT
    {
        public static UsuarioDTO FromDTO(Usuario user)
        {
            if (user == null) return null;
            return new UsuarioDTO
            {
                Id = user.Id,
                Email = user.Email.DireccionEmail,
                Contrasenia = user.Contrasenia.Password,
                Rol = user.Rol.RolValor
            };
        }
        public static UsuarioDTO ToDTO(Usuario user)
        {
            return new UsuarioDTO
            {
                Id = user.Id,
                Email = user.Email.DireccionEmail,
                Contrasenia = user.Contrasenia.Password,
                Rol = user.Rol.RolValor
            };
        }
        
    }
}

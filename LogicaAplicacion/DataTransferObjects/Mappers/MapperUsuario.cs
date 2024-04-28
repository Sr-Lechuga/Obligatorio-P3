using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDTO(AltaUsuarioDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return new Usuario(dto.Email, dto.Nombre, dto.Apellido, dto.Password, dto.Rol);
        }
        public static Usuario FromDTO(UsuarioModificacionDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var usuario = new Usuario(dto.Email, dto.Nombre, dto.Apellido, dto.Password, dto.Rol)
            {
                Id = dto.Id
            };
            return usuario;
        }

        public static UsuarioListadoDTO ToDTO(Usuario user)
        {
            return new UsuarioListadoDTO()
            {
                Email = user.Email.DireccionEmail,
                Password = user.Contrasenia.Password,
                Rol = user.Rol,
                Nombre = user.NombreCompleto.Nombre,
                Apellido = user.NombreCompleto.Apellido,
                Id = user.Id
            };
        }

        public static IEnumerable<UsuarioListadoDTO> FromList(IEnumerable<Usuario> users)
        {
            return users.Select(x => ToDTO(x));
        }
    }
}

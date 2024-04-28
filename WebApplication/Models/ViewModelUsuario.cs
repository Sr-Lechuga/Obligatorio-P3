using LogicaAplicacion.DataTransferObjects.Models.Usuarios;

namespace WebApplication.Models
{
    public class ViewModelUsuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AltaUsuarioDTO GetUsuarioDto()
        {
            AltaUsuarioDTO usuarioDto = new AltaUsuarioDTO()
            {
                Email = Email,
                Password = Password
            };
            return usuarioDto;
        }

        public ViewModelUsuario() { }

        public ViewModelUsuario(AltaUsuarioDTO usuarioDto)
        {
            Email = usuarioDto.Email;
            Password = usuarioDto.Password;
        }

    }
}

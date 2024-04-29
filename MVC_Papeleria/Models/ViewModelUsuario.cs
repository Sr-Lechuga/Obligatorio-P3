using LogicaAplicacion.DataTransferObjects.Models.Usuarios;

namespace MVC_Papeleria.Models
{
    public class ViewModelUsuario
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UsuarioAltaDTO GetUsuarioDto()
        {
            UsuarioAltaDTO usuarioDto = new UsuarioAltaDTO()
            {
                Email = Email,
                Password = Password
            };
            return usuarioDto;
        }

        public ViewModelUsuario() { }

        public ViewModelUsuario(UsuarioAltaDTO usuarioDto)
        {
            Email = usuarioDto.Email;
            Password = usuarioDto.Password;
        }

    }
}

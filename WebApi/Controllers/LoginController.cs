using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICasoUsoGetUsuarioByEmail _getUser;

        public LoginController(ICasoUsoGetUsuarioByEmail getUser)
        {
            _getUser = getUser;
        }

        /// <summary>
        /// Metodo que permite iniciar sesion y obtener un token.
        /// </summary>
        /// <param name="user">Usuario con rol que desea iniciar sesion</param>
        /// <returns>Retorna datos del usuario y token</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<UsuarioDTO> Login([FromBody] UsuarioDTO user)
        {
            try
            {
                ManejadorJWT handler = new ManejadorJWT(_getUser);
                var usuario = handler.ObtenerUsuario(user.Email);
                if (usuario == null || user.Contrasenia != usuario.Contrasenia)
                {
                    return Unauthorized("Credenciales invalidas");
                }
                var token = ManejadorJWT.GenerarToken(usuario);
                return Ok(new
                {
                    Token = token,
                    Usuario = usuario
                });
            }
            catch (Exception ex)
            {

                return Unauthorized(new { Message = "Se produjo un error, intente nuevamente" });
            }
        }
    }
}

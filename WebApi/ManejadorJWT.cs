using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi
{
    public class ManejadorJWT
    {
        private ICasoUsoGetUsuarioByEmail _getUser;

        public ManejadorJWT(ICasoUsoGetUsuarioByEmail getUser)
        {
            _getUser = getUser;
        }

        public static string GenerarToken(UsuarioDTO usuarioDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //Clave secreta, signature:

            var clave = Encoding.ASCII.GetBytes("CharliXCX!NewAlbum-BRAT-isOUTNOW!STREAM!!!");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email, usuarioDTO.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public UsuarioDTO ObtenerUsuario(string email)
        {
            var usuario = _getUser.FindUserbyEmail(email);
            return usuario;
        }
    }
}

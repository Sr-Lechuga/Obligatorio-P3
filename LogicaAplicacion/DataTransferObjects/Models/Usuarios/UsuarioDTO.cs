using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Usuarios
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string? ContraseniaEncriptada { get; set; }
        public ERol Rol { get; set; }

    }
}

﻿using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Usuarios
{
    public class UsuarioListadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordEncriptada { get; set; }
        public int Rol { get; set; }

        public UsuarioListadoDTO() { }
    }
}

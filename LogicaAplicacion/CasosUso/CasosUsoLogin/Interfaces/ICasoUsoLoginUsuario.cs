using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoLogin.Interfaces
{
    public interface ICasoUsoLoginUsuario
    {
        public Usuario Ejecutar(string email, string contraseña);
    }
}

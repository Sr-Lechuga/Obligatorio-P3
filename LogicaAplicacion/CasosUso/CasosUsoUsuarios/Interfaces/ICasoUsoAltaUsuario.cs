using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces
{
    public interface ICasoUsoAltaUsuario
    {
        public void AltaUsuario(UsuarioAltaDTO usuario);
    }
}

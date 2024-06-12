using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuarios.Implementaciones
{
    public class CasoUsoGetUsuarioByEmail : ICasoUsoGetUsuarioByEmail
    {
        private IRepositorioUsuarios _repoUsuarios;
        public CasoUsoGetUsuarioByEmail(IRepositorioUsuarios repoUsuarios)
        {
            _repoUsuarios = repoUsuarios;
        }

        public UsuarioDTO FindUserbyEmail(string email)
        {
            return MapperUsuarioParaJWT.FromDTO(_repoUsuarios.ObtenerUsuarioPorEmail(email));
        }
    }
}

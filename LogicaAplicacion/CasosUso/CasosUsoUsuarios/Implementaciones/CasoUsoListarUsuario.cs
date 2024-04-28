using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuarios.Implementaciones
{
    public class CasoUsoListarUsuario : ICasoUsoListarUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; init; }

        public CasoUsoListarUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            // Inyeccion de dependencia
            RepositorioUsuarios = repositorioUsuarios;
        }

        public IEnumerable<UsuarioListadoDTO> ListarUsuarios()
        {
            return MapperUsuario.FromList(RepositorioUsuarios.GetAll());
        }

    }
}

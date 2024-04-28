using AccesoDatos.Implementaciones.EntityFramework;
using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoUsuarios.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoUsuarios.Implementaciones
{
    public class CasoUsoBuscarUsuario : ICasoUsoBuscarUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; init; }

        public CasoUsoBuscarUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            // Inyeccion de dependencia
            RepositorioUsuarios = repositorioUsuarios;
        }

        public UsuarioListadoDTO BuscarUsuario(int id)
        {
            Usuario user = RepositorioUsuarios.GetById(id) ?? throw new UsuarioNoEncontradoException("No hay usuarios con ese id");
            
            UsuarioListadoDTO userDTO = MapperUsuario.ToDTO(user);
            
            return userDTO;
        }

    }
}

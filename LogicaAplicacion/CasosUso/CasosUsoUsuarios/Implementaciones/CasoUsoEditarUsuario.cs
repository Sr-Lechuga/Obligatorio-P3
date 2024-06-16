using AccesoDatos.Implementaciones.EntityFramework;
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
    public class CasoUsoEditarUsuario : ICasoUsoEditarUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; init; }

        public CasoUsoEditarUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            // Inyeccion de dependencia
            RepositorioUsuarios = repositorioUsuarios;
        }

        public void EditarUsuario(int idUsuario,UsuarioModificacionDTO usuarioModificadoDTO)
        {
            Usuario buscar = RepositorioUsuarios.GetById(idUsuario);

            //No se puede modificar ni el rol ni el email
            usuarioModificadoDTO.Rol = buscar.Rol;
            usuarioModificadoDTO.Email = buscar.Email;


            Usuario usuarioModificado = MapperUsuario.FromDTO(usuarioModificadoDTO);
            RepositorioUsuarios.Update(idUsuario, usuarioModificado);
        }

    }
}

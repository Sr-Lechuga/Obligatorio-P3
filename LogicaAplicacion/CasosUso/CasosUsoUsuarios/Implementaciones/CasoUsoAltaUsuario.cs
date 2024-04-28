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
    public class CasoUsoAltaUsuario : ICasoUsoAltaUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; init; }

        public CasoUsoAltaUsuario(IRepositorioUsuarios repositorioUsuarios)
        {
            // Inyeccion de dependencia
            RepositorioUsuarios = repositorioUsuarios;
        }

        public void AltaUsuario(AltaUsuarioDTO usuarioNuevo)
        {
            if (usuarioNuevo == null)
            {
                throw new ArgumentNullException(nameof(usuarioNuevo));
            }
            Usuario user = MapperUsuario.FromDTO(usuarioNuevo);
            RepositorioUsuarios.Add(user);
        }

    }
}

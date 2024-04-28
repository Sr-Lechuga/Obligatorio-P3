using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoLogin.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoLogin.Implementaciones
{
    public class CasoUsoLoginUsuario : ICasoUsoLoginUsuario
    {
        public IRepositorioUsuarios RepositorioUsuarios { get; init; }
        public CasoUsoLoginUsuario(IRepositorioUsuarios repositorioUsuario)
        {
            RepositorioUsuarios = repositorioUsuario;
        }
        public Usuario Ejecutar(string email, string contraseña)
        {
            Usuario buscado = RepositorioUsuarios.ObtenerUsuarioPorEmail(email);

            return buscado.Contrasenia.Password == contraseña ? buscado : null;
        }


    }
}

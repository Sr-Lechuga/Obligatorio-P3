using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioUsuarios : IRepositorioCRUD<Usuario>
    {
        public Usuario ObtenerUsuarioPorEmail(string email);
    }
}

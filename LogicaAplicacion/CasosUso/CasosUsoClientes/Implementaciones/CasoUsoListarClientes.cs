using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoClientes.Implementaciones
{
    public class CasoUsoListarClientes : ICasoUsoListarClientes
    {
        public IRepositorioClientes RepositorioClientes { get; init; }

        public CasoUsoListarClientes(IRepositorioClientes repositorioClientes)
        {
            // Inyeccion de dependencia
            RepositorioClientes = repositorioClientes;

        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return RepositorioClientes.GetAll();
        }
    }
}

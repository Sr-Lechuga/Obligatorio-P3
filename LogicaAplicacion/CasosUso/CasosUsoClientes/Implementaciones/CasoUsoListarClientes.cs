using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Clientes;
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

        public IEnumerable<ClienteDTO> ListarClientes()
        {
            return MapperCliente.FromList(RepositorioClientes.GetAll());
        }
    }
}

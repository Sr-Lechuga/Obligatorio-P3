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
    public class CasoUsoEditarCliente : ICasoUsoEditarCliente
    {
        public IRepositorioClientes RepositorioClientes { get; init; }

        public CasoUsoEditarCliente(IRepositorioClientes repositorioClientes)
        {
            // Inyeccion de dependencia
            RepositorioClientes = repositorioClientes;
        }

        public void EditarCliente(int idCliente,Cliente cliente)
        {
            RepositorioClientes.Update(idCliente,cliente);
        }

    }
}

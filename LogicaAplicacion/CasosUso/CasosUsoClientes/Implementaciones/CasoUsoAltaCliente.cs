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
    public class CasoUsoAltaCliente : ICasoUsoAltaCliente
    {
        public IRepositorioClientes RepositorioClientes { get; init; }

        public CasoUsoAltaCliente(IRepositorioClientes repositorioClientes)
        {
            // Inyeccion de dependencia
            RepositorioClientes = repositorioClientes;
        }

        public void AltaCliente(Cliente cliente)
        {
            this.RepositorioClientes.Add(cliente);
        }

    }
}

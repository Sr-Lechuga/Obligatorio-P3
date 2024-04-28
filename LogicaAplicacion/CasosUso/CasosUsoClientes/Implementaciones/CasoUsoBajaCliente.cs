using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoClientes.Implementaciones
{
    public class CasoUsoBajaCliente : ICasoUsoBajaCliente
    {
        public IRepositorioClientes RepositorioClientes { get; set; }

        public CasoUsoBajaCliente(IRepositorioClientes repositorioClientes)
        {
            // Inyeccion de dependencia
            RepositorioClientes = repositorioClientes;

        }

        public void BajaCliente(int id)
        {
            this.RepositorioClientes.Remove(id);
        }

    }
}

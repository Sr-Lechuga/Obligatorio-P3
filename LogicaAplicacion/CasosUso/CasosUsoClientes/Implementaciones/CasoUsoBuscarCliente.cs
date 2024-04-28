using AccesoDatos.Implementaciones.EntityFramework;
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
using static System.Net.Mime.MediaTypeNames;

namespace LogicaAplicacion.CasosUso.CasosUsoClientes.Implementaciones
{
    public class CasoUsoBuscarCliente : ICasoUsoBuscarCliente
    {
        public IRepositorioClientes RepositorioClientes { get; set; }

        public CasoUsoBuscarCliente(IRepositorioClientes repositorioClientes)
        {
            // Inyeccion de dependencia
            RepositorioClientes = repositorioClientes;
        }

        public Cliente BuscarClientePorId(int id)
        {
            return RepositorioClientes.GetById(id);
        }

        public Cliente BuscarClientePorRut(string rut)
        {
            return RepositorioClientes.GetByRut(rut);
        }


        public IEnumerable<ClienteDTO> BuscarClientePorTexto(string texto)
        {
            return MapperCliente.FromList(RepositorioClientes.GetByText(texto));
        }

        public IEnumerable<ClienteDTO> BuscarClientePorMonto(decimal monto)
        {
            return MapperCliente.FromList(RepositorioClientes.GetByMonto(monto));
        }
    }
}

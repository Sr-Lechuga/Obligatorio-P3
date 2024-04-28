using LogicaAplicacion.DataTransferObjects.Models.Clientes;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces
{
    public interface ICasoUsoBuscarCliente
    {
        public Cliente BuscarClientePorId(int id);
        public Cliente BuscarClientePorRut(string rut);
        public IEnumerable<ClienteDTO> BuscarClientePorTexto(string texto);
        public IEnumerable<ClienteDTO> BuscarClientePorMonto(decimal texto);

    }
}

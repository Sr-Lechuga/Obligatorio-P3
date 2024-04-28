using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoClientes.Interfaces
{
    public interface ICasoUsoEditarCliente
    {
        public void EditarCliente(int idCliente, Cliente clienteEditado);

    }
}

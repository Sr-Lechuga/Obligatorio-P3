using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces
{
    public interface ICasoUsoListarOrdenadoDescendentementePorFechaPedido
    {
        public IEnumerable<PedidoDTO> ListarPedidoOrdenadoDescendentementePorFecha();
    }
}

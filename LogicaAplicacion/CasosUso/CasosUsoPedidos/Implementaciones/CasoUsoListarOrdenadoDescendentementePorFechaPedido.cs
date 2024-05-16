using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Implementaciones
{
    public class CasoUsoListarOrdenadoDescendentementePorFechaPedido : ICasoUsoListarOrdenadoDescendentementePorFechaPedido
    {
        public IRepositorioPedidos _repositorioPedidos;

        public CasoUsoListarOrdenadoDescendentementePorFechaPedido(IRepositorioPedidos repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }
        public IEnumerable<PedidoDTO> ListarPedidoOrdenadoDescendentementePorFecha()
        {
            return MapperPedido.ToListAll(_repositorioPedidos.ListadoDescendente());
        }
    }
}

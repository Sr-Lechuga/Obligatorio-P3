using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System.Linq;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperPedido
    {
        public static Pedido FromDTO(PedidoDTO pedidoDTO) 
        {
            Pedido pedido = new Pedido
            {
                FechaPrometida = pedidoDTO.FechaPrometida,
                FechaCreado = pedidoDTO.FechaCreado,
                Cliente = pedidoDTO.Cliente,
                IVAAplicado = pedidoDTO.IVAAplicado,
                FechaEntregado = pedidoDTO.FechaEntregado,
                Estado = pedidoDTO.Estado,
                Lineas = MapperLineaPedido.ToList(pedidoDTO.Lineas),
                Express = pedidoDTO.Express
            };

            if (pedido.Cliente == null)
                pedido.Total = pedido.CalcularCostoBase();
            else
                pedido.Total = pedido.CalcularTotal();

            return pedido;
        }

        public static PedidoDTO ToDTO(Pedido pedido)
        {
            if (pedido == null)
                return null;

            PedidoDTO pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                FechaPrometida = pedido.FechaPrometida,
                FechaCreado = pedido.FechaCreado,
                Cliente = pedido.Cliente,
                IVAAplicado = pedido.IVAAplicado,
                FechaEntregado = pedido.FechaEntregado,
                Estado = pedido.Estado,
                Lineas = MapperLineaPedido.FromList(pedido.Lineas),
                Express = pedido.Express
            };
            if (pedido.Cliente == null)
                pedidoDTO.Total = pedido.CalcularCostoBase();
            else
                pedidoDTO.Total = pedido.CalcularTotal();
            return pedidoDTO;
        }

        public static IEnumerable<PedidoDTO> ToListAll(IEnumerable<Pedido> pedidos)
        {
            return pedidos.Select(p => ToDTO(p)).ToList();
        }

    }
}

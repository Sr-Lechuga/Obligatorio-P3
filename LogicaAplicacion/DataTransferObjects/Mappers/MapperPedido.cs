using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperPedido
    {
        public static PedidoExpress FromDTO(PedidoDTO pedidoExpressDTO)
        {

            PedidoExpress pedidoExpress = new PedidoExpress
            {
                FechaPrometida = pedidoExpressDTO.FechaPrometida,
                FechaCreado = pedidoExpressDTO.FechaCreado,
                Cliente = pedidoExpressDTO.Cliente,
                Total = pedidoExpressDTO.Total,
                IVAAplicado = pedidoExpressDTO.IVAAplicado,
                FechaEntregado = pedidoExpressDTO.FechaEntregado,
                Estado = pedidoExpressDTO.Estado,
                Lineas = MapperLineaPedido.ToList(pedidoExpressDTO.Lineas)

            };
            return pedidoExpress;
        }

        public PedidoComun FromDTO(PedidoComunDTO pedidoComunDTO)
        {


            PedidoComun pedidoComun = new PedidoComun
            {
                FechaPrometida = pedidoComunDTO.FechaPrometida,
                FechaCreado = pedidoComunDTO.FechaCreado,
                Cliente = pedidoComunDTO.Cliente,
                Total = pedidoComunDTO.Total,
                IVAAplicado = pedidoComunDTO.IVAAplicado,
                FechaEntregado = pedidoComunDTO.FechaEntregado,
                Estado = pedidoComunDTO.Estado,
                Lineas = MapperLineaPedido.ToList(pedidoComunDTO.Lineas)

            };
            return pedidoComun;

        }

        public static PedidoExpressDTO ToDTO(PedidoExpress pedido)
        {
            if (pedido == null)
                return null;

            PedidoExpressDTO pedidoDTO = new PedidoExpressDTO
            {

                FechaPrometida = pedido.FechaPrometida,
                FechaCreado = pedido.FechaCreado,
                Cliente = pedido.Cliente,
                Total = pedido.Total,
                IVAAplicado = pedido.IVAAplicado,
                FechaEntregado = pedido.FechaEntregado,
                Estado = pedido.Estado,
                Lineas = MapperLineaPedido.FromList(pedido.Lineas),

            };
            return pedidoDTO;
        }
        public static PedidoComunDTO ToDTO(PedidoComun pedido)
        {
            if (pedido == null)
                return null;

            PedidoComunDTO pedidoDTO = new PedidoComunDTO
            {
                FechaPrometida = pedido.FechaPrometida,
                FechaCreado = pedido.FechaCreado,
                Cliente = pedido.Cliente,
                Total = pedido.Total,
                IVAAplicado = pedido.IVAAplicado,
                FechaEntregado = pedido.FechaEntregado,
                Estado = pedido.Estado,
                Lineas = MapperLineaPedido.FromList(pedido.Lineas),
            };
            return pedidoDTO;
        }
        public static List<PedidoDTO> ToList(IEnumerable<Pedido> pedidos)
        {
            return pedidos.Select(x =>
            {
            if (x.GetType() == typeof(PedidoComun))
            {
                return MapperPedido.ToDTO((PedidoComun)x);
            }
            else
            {
                return MapperPedido.ToDTO((PedidoExpress)x);
            }

            ).ToList();
        }
    }
}

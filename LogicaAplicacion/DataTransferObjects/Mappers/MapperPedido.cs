using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System.Linq;

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

        public static PedidoComun FromDTO(PedidoComunDTO pedidoComunDTO)
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
        public static List<PedidoDTO> ToListAll(IEnumerable<Pedido> pedidos)
        {
            IEnumerable<PedidoExpressDTO> express = pedidos.OfType<PedidoExpress>().Select(p => ToDTO(p));
            IEnumerable<PedidoComunDTO> comun = pedidos.OfType<PedidoComun>().Select(p => ToDTO(p));

            IEnumerable<PedidoExpress> expressDTOs = express.Select(p => FromDTO(p));
            IEnumerable<PedidoComun> comunDTOs = comun.Select(p => FromDTO(p));

            IEnumerable<PedidoDTO> allDTOs = expressDTOs.Cast<PedidoDTO>().Concat(comunDTOs.Cast<PedidoDTO>());
            return allDTOs.ToList();
        }

    }
}

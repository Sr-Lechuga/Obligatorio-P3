using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System.Linq;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperPedido
    {
        public static PedidoExpress FromDTO(PedidoExpressDTO pedidoExpressDTO)
        {

            PedidoExpress pedidoExpress = new PedidoExpress
            {
                FechaPrometida = pedidoExpressDTO.FechaPrometida,
                FechaCreado = pedidoExpressDTO.FechaCreado,
                Cliente = pedidoExpressDTO.Cliente,
                IVAAplicado = pedidoExpressDTO.IVAAplicado,
                FechaEntregado = pedidoExpressDTO.FechaEntregado,
                Estado = pedidoExpressDTO.Estado,
                Lineas = MapperLineaPedido.ToList(pedidoExpressDTO.Lineas)

            };
            pedidoExpress.Total = pedidoExpress.CalcularTotal();
            return pedidoExpress;
        }

        public static PedidoComun FromDTO(PedidoComunDTO pedidoComunDTO)
        {


            PedidoComun pedidoComun = new PedidoComun
            {
                FechaPrometida = pedidoComunDTO.FechaPrometida,
                FechaCreado = pedidoComunDTO.FechaCreado,
                Cliente = pedidoComunDTO.Cliente,
                IVAAplicado = pedidoComunDTO.IVAAplicado,
                FechaEntregado = pedidoComunDTO.FechaEntregado,
                Estado = pedidoComunDTO.Estado,
                Lineas = MapperLineaPedido.ToList(pedidoComunDTO.Lineas)

            };
            pedidoComun.Total = pedidoComun.CalcularTotal();
            return pedidoComun;

        }
        public static Pedido FromDTO(PedidoDTO pedido) 
        {
            if(pedido.Express) 
            {
                return FromDTO((PedidoExpressDTO)pedido);
            }
            else
            {
                return FromDTO((PedidoComunDTO)pedido);
            }
        }
        public static PedidoExpressDTO ToDTO(PedidoExpress pedido)
        {
            if (pedido == null)
                return null;

            PedidoExpressDTO pedidoDTO = new PedidoExpressDTO
            {
                Id = pedido.Id,
                FechaPrometida = pedido.FechaPrometida,
                FechaCreado = pedido.FechaCreado,
                Cliente = pedido.Cliente,
                Total = pedido.CalcularTotal(),
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
                Id = pedido.Id,
                FechaPrometida = pedido.FechaPrometida,
                FechaCreado = pedido.FechaCreado,
                Cliente = pedido.Cliente,
                Total = pedido.CalcularTotal(),
                IVAAplicado = pedido.IVAAplicado,
                FechaEntregado = pedido.FechaEntregado,
                Estado = pedido.Estado,
                Lineas = MapperLineaPedido.FromList(pedido.Lineas),
            };
            return pedidoDTO;
        }
        public static List<PedidoDTO> ToListAll(IEnumerable<Pedido> pedidos)
        {
            //convertimos los pedidos a DTO
            IEnumerable<PedidoExpressDTO> expressDTOs = pedidos.OfType<PedidoExpress>().Select(p => ToDTO(p));
            IEnumerable<PedidoComunDTO> comunDTOs = pedidos.OfType<PedidoComun>().Select(p => ToDTO(p));

            //concatenamos para mostrar todos los pedidos
            IEnumerable<PedidoDTO> allDTOs = expressDTOs.Cast<PedidoDTO>().Concat(comunDTOs.Cast<PedidoDTO>());
            return allDTOs.ToList();
        }

    }
}

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
                //TODO Hacer el mapper de lineaPedido
                Lineas = pedidoExpressDTO.Lineas

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
                //TODO Hacer el mapper de lineaPedido
                Lineas = pedidoComunDTO.Lineas

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
                //TODO Hacer el mapper de lineaPedido
                Lineas = pedido.Lineas,

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
                //TODO Hacer el mapper de lineaPedido
                Lineas = pedido.Lineas,
            };
            return pedidoDTO;
        }
    }
}

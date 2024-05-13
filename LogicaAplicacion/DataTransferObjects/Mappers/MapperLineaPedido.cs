using LogicaAplicacion.DataTransferObjects.Models.Clientes;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperLineaPedido
    {
        public static LineaPedidoDTO ToDTO(LineaPedido lineaPedido)
        {
            return new LineaPedidoDTO
            {
                ArticuloId = lineaPedido.ArticuloId,
                PedidoId = lineaPedido.PedidoId,
                CantidadArticulo = lineaPedido.CantidadArticulo,
                PrecioUnitario = lineaPedido.PrecioUnitario,
                Articulo = lineaPedido.Articulo
            };
        }
        public static LineaPedidoDTO FromDTO(LineaPedidoDTO lineaPedidoDTO)
        {
            return new LineaPedidoDTO
            {
                ArticuloId = lineaPedidoDTO.ArticuloId,
                PedidoId = lineaPedidoDTO.PedidoId,
                CantidadArticulo = lineaPedidoDTO.CantidadArticulo,
                PrecioUnitario = lineaPedidoDTO.PrecioUnitario,
                Articulo = lineaPedidoDTO.Articulo
            };
        }
        
    }
}

using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Mappers
{
    public class MapperPedido
    {
        public static Pedido FromDTO(PedidoDTO pedido) 
        {

            if (pedido.EsExpress)
            {
                PedidoExpress pedidoExpress = new PedidoExpress()
                {
                    FechaPrometida = pedido.FechaPrometida,

                };
                return pedidoExpress;
            }
            else
            {
                PedidoComun pedidoComun = new PedidoComun()
                {

                };
                return pedidoComun;
            }
        }
    }
}

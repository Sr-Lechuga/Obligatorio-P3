using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        //TODO: Pasar esto a archivo de configuracion
        public static int s_PlazoMaximo;

        public PedidoExpress()
        {
        }

        public override decimal CalcularTotal()
        {
            decimal totalPedidoBase = 0;
            foreach (LineaPedido linea in Lineas)
            {
                totalPedidoBase += linea.CantidadArticulo * linea.PrecioUnitario;
            }

            TimeSpan diferenciaFechas = FechaPrometida - FechaCreado;
            int diferenciaDias = diferenciaFechas.Days;

            return diferenciaDias < 1 ? totalPedidoBase *= 1.15M : totalPedidoBase *= 1.1M;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido
    {
        //TODO: Pasar esto a archivo de configuracion
        public static int s_PlazoMinimo;

       public PedidoComun() 
       {

       }

        public override decimal CalcularTotal()
        {
            decimal totalPedidoBase = 0;
            foreach (LineaPedido linea in Lineas)
            {
                totalPedidoBase += linea.CantidadArticulo * linea.PrecioUnitario;
            }

            if (Cliente.Direccion.Distancia > 100)
                totalPedidoBase *= 1.05M;

            return totalPedidoBase;
        }
    }
}

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

        public override double CalcularTotal()
        {
            double totalPedidoBase = 0;

            if (Cliente.Direccion.Distancia > 100)
                totalPedidoBase *= 1.05;

            return totalPedidoBase;
        }
    }
}

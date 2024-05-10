﻿using System;
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

        public override double CalcularTotal()
        {
            double totalPedidoBase = 0;

            TimeSpan diferenciaFechas = FechaPrometida - FechaCreado;
            int diferenciaDias = diferenciaFechas.Days;

            return diferenciaDias < 1 ? totalPedidoBase *= 1.15 : totalPedidoBase *= 1.1;
        }

    }
}

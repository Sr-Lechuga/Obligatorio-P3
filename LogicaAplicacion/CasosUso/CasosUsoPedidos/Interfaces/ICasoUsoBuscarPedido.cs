﻿using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces
{
    public interface ICasoUsoBuscarPedido
    {
        public PedidoDTO BuscarPedido(int id);

    }
}

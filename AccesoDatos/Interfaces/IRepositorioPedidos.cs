﻿using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IRepositorioPedidos : IRepositorioCRUD<Pedido>
    {
        public void AnularPedido(int id);
        public IEnumerable<Pedido> ListadoDescendente();
    }
}

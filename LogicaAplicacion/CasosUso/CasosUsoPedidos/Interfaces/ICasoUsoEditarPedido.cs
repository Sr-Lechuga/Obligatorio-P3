using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces
{
    public interface ICasoUsoEditarPedido
    {
        public void EditarPedido(int idPedido,Pedido pedido);

    }
}

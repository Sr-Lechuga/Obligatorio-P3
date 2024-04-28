using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Implementaciones
{
    public class CasoUsoEditarPedido : ICasoUsoEditarPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; init; }

        public CasoUsoEditarPedido(IRepositorioPedidos repositorioPedidos)
        {
            // Inyeccion de dependencia
            this.RepositorioPedidos = repositorioPedidos;
        }

        public void EditarPedido(int idPedido,Pedido pedido)
        {
            this.RepositorioPedidos.Update(idPedido,pedido);
        }

    }
}

using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using LogicaAplicacion.DataTransferObjects.Mappers;
using LogicaAplicacion.DataTransferObjects.Models.Pedidos;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Implementaciones
{
    public class CasoUsoAltaPedido : ICasoUsoAltaPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; init; }

        public CasoUsoAltaPedido(IRepositorioPedidos repositorioPedidos)
        {
            // Inyeccion de dependencia
            this.RepositorioPedidos = repositorioPedidos;
        }

        public void AltaPedido(PedidoDTO pedido)
        {
            this.RepositorioPedidos.Add(MapperPedido.FromDTO(pedido));
        }

    }
}

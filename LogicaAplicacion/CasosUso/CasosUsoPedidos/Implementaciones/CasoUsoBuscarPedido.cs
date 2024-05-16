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
    public class CasoUsoBuscarPedido : ICasoUsoBuscarPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; init; }

        public CasoUsoBuscarPedido(IRepositorioPedidos repositorioPedidos)
        {
            // Inyeccion de dependencia
            RepositorioPedidos = repositorioPedidos;
        }

        public PedidoDTO BuscarPedido(int id)
        {
            return MapperPedido.ToDTO(RepositorioPedidos.GetById(id));
        }

    }
}

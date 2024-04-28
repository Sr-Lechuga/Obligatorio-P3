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
    public class CasoUsoBuscarPedido : ICasoUsoBuscarPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; init; }

        public CasoUsoBuscarPedido(IRepositorioPedidos repositorioPedidos)
        {
            // Inyeccion de dependencia
            RepositorioPedidos = repositorioPedidos;
        }

        public Pedido BuscarPedido(int id)
        {
            return this.RepositorioPedidos.GetById(id);
        }

    }
}

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
    public class CasoUsoAltaPedido : ICasoUsoAltaPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; init; }

        public CasoUsoAltaPedido(IRepositorioPedidos repositorioPedidos)
        {
            // Inyeccion de dependencia
            this.RepositorioPedidos = repositorioPedidos;
        }

        public void AltaPedido(Pedido pedido)
        {
            this.RepositorioPedidos.Add(pedido);
        }

    }
}

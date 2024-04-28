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
    public class CasoUsoListarPedido : ICasoUsoListarPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; init; }

        public CasoUsoListarPedido(IRepositorioPedidos repositorioPedidos)
        {
            /// Inyeccion de dependencia
            RepositorioPedidos = repositorioPedidos;
        }

        public IEnumerable<Pedido> ListarPedidos()
        {
            return this.RepositorioPedidos.GetAll();
        }

    }
}

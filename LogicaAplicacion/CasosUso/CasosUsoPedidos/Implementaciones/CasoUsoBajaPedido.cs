using AccesoDatos.Interfaces;
using LogicaAplicacion.CasosUso.CasosUsoPedidos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso.CasosUsoPedidos.Implementaciones
{
    public class CasoUsoBajaPedido : ICasoUsoBajaPedido
    {
        public IRepositorioPedidos RepositorioPedidos { get; set; }

        public CasoUsoBajaPedido(IRepositorioPedidos repositorioPedidos)
        {
            // Inyeccion de dependencia
            this.RepositorioPedidos = repositorioPedidos;
        }

        public void BajaPedido(int id)
        {
            this.RepositorioPedidos.AnularPedido(id);
        }

    }
}

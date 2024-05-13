using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Pedidos
{
    public class LineaPedidoDTO
    {
        public int ArticuloId { get; set; }
        public int PedidoId { get; set; }
        public int CantidadArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public required Articulo Articulo { get; set; }
    }
}

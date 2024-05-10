using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(PedidoId),nameof(ArticuloId))]
    public class LineaPedido
    {

        #region Properties
        public int ArticuloId { get; set; }
        public int PedidoId { get; set; }
        public int CantidadArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Articulo Articulo { get; set; }
        #endregion

        #region Constructors
        public LineaPedido(int cantidadArticulo, decimal precioUnitario, Articulo articulo)
        {
            CantidadArticulo = cantidadArticulo;
            PrecioUnitario = precioUnitario;
            Articulo = articulo;
        }
        public LineaPedido() { }
        #endregion

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [PrimaryKey(nameof(PedidoId),nameof(ArticuloId))]
    public class LineaPedido
    {

        #region Properties
        [Display(Name = "Articulo Id")]
        public int ArticuloId { get; set; }
        [Display(Name = "Pedido Id")]
        public int PedidoId { get; set; }
        [Display(Name = "Cantidad de articulos")]
        public int CantidadArticulo { get; set; }
        [Display(Name = "Precio")]
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

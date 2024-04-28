using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class LineaPedido
    {
        #region Properties
        public int CantidadArticulo { get; set; }
        public decimal PrecioUnitario { get; set; }
        public List<Articulo> Articulos { get; set; }
        #endregion

        #region Constructors
        public LineaPedido(int cantidadArticulo, decimal precioUnitario)
        {
            CantidadArticulo = cantidadArticulo;
            PrecioUnitario = precioUnitario;
            Articulos = [];
        }
        private LineaPedido() { }
        #endregion

    }
}

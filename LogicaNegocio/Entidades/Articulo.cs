using LogicaNegocio.Excepciones.Articulos;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Articulo
    {
        #region Properties
        public int Id { get; set; }
        public NombreArticulo Nombre { get; set; }
        public DescripcionArticulo Descripcion { get; set; }
        public CodigoArticulo Codigo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        #endregion

        #region Constructor
        public Articulo(string nombre, string descripcion, long codigo, decimal precioVenta, int stock)
        {
            Nombre = new NombreArticulo(nombre);
            Descripcion = new DescripcionArticulo(descripcion);
            Codigo = new CodigoArticulo(codigo);
            PrecioVenta = precioVenta;
            Stock = stock;
        }

        public Articulo(int id, string nombre, string descripcion, long codigo, decimal precioVenta, int stock)
        {
            Id = id;
            Nombre = new NombreArticulo(nombre);
            Descripcion = new DescripcionArticulo(descripcion);
            Codigo = new CodigoArticulo(codigo);
            PrecioVenta = precioVenta;
            Stock = stock;
        }

        public Articulo() { }
        #endregion

    }
}

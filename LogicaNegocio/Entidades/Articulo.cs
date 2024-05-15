using LogicaNegocio.Excepciones.Articulos;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(5, int.MinValue, ErrorMessage = "La descripción debe tener minimo 5 caracteres")]
        public DescripcionArticulo Descripcion { get; set; }
        [Range(13, int.MinValue, ErrorMessage = "El código debe tener 13 dígitos")]
        public CodigoArticulo Codigo { get; set; }
        [Display(Name = "Precio")]
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

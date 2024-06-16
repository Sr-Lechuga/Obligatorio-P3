using LogicaNegocio.Excepciones.Articulos;
using LogicaNegocio.Interfaces;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Articulo : IValidable<Articulo>
    {
        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        //[Range(5, int.MinValue, ErrorMessage = "La descripción debe tener minimo 5 caracteres")]
        public string Descripcion { get; set; }
        //[Range(13, int.MinValue, ErrorMessage = "El código debe tener 13 dígitos")]
        public long Codigo { get; set; }
        [Display(Name = "Precio")]
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        #endregion

        #region Constructor
        public Articulo(string nombre, string descripcion, long codigo, decimal precioVenta, int stock)
        {
            EsValido();
            Nombre = nombre;
            Descripcion = descripcion;
            Codigo = codigo;
            PrecioVenta = precioVenta;
            Stock = stock;
        }

        public Articulo(int id, string nombre, string descripcion, long codigo, decimal precioVenta, int stock)
        {
            EsValido();
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Codigo = codigo;
            PrecioVenta = precioVenta;
            Stock = stock;
        }

        public Articulo() { }
        #endregion

        public void EsValido()
        {
            ValidarCodigo();
            ValidarNombre();
            ValidarDescripcion();
        }

        private void ValidarCodigo()
        {
            string patronValido = @"\d{13}";

            if (string.IsNullOrEmpty(Codigo.ToString()))
                throw new ArticuloNoValidoException("El código del artículo no puede estar vacio");
            else if (!Regex.IsMatch(Codigo.ToString(), patronValido))
                throw new ArticuloNoValidoException("El código del artículo debe tener 13 digitos");
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ArticuloNoValidoException("Debe ingresar un nombre para el articulo");
            else if (Nombre.Length < 10 || Nombre.Length > 200)
                throw new ArticuloNoValidoException("El nombre del artículo debetener entre 10 y 200 carácteres");
        }

        private void ValidarDescripcion()
        {
            if (Descripcion.Length < 5)
                throw new ArticuloNoValidoException("La descripción del artículo debe contener al menso 5 caracteres");
        }
    }
}

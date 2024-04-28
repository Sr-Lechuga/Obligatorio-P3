using LogicaNegocio.Excepciones.Articulos;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Articulo : IValidable<Articulo>
    {
        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }
        #endregion

        #region Constructor
        public Articulo(string nombre, string descripcion, long codigo, int precioVenta, int stock)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
        }

        public Articulo(int id, string nombre, string descripcion, long codigo, int precioVenta, int stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Codigo = codigo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.EsValido();
        }
        public Articulo() { }
        #endregion

        public void EsValido()
        {
            //TODO: Llevar validacion a VO
            if (Nombre == null) throw new ArticuloNoValidoException("Nombre del articulo no puede ser vacio");
            if (Nombre.Length > 10 && Nombre.Length < 200) throw new ArticuloNoValidoException("Nombre debe contener entre 10 y 200 caracteres");
            if (Descripcion.Length < 5) throw new ArticuloNoEncontradoException("La descripcion debe de contener al menos 5 caracteres");
            if (Codigo.ToString().Length > 13) throw new ArticuloNoEncontradoException("El codigo tiene maximo 13 digitos");
            if (Codigo == null) throw new ArticuloNoEncontradoException("Codigo del articulo no puede ser vacio");
        }

    }
}

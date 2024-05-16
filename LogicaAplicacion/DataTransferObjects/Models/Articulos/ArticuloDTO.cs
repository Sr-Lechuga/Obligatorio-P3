using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Articulos
{
    public class ArticulosDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre para el Articulo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripcion para el Articulo")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar un codigo para el Articulo")]
        public long Codigo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un precio de venta para el Articulo")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "Debe ingresar un precio de venta para el Articulo")]
        public int Stock { get; set; }

        public ArticulosDTO() { }
    }
}

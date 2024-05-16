using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Pedidos
{
    public class LineaPedidoDTO
    {
        [Required]
        public int ArticuloId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [DisplayName("Cantidad del articulo")]
        [Required(ErrorMessage = "Debe ingresar una cantidad de articulos para el articulo seleccionado")]
        public int CantidadArticulo { get; set; }

        [DisplayName("Precio del articulo")]
        public decimal PrecioUnitario { get; set; }

        public required Articulo Articulo { get; set; }
    }
}

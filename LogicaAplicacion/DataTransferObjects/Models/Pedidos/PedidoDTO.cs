using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Pedidos
{
    public class PedidoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha prometida para el Pedido")]
        [DisplayName("Fecha Prometida")]
        public DateTime FechaPrometida { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha de creado para el Pedido")]
        [DisplayName("Fecha de creacion")]
        public DateTime FechaCreado { get; set; }

        [Required(ErrorMessage = "Debe ingresar un cliente para el Pedido")]
        [DisplayName("Cliente")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un total para el Pedido")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Debe ingresar un IVA para el Pedido")]
        [DisplayName("Tasa de impuestos aplicados")]
        public double IVAAplicado { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha de entrega para el Pedido")]
        [DisplayName("Fecha de entrega")]
        public DateTime? FechaEntregado { get; set; }

        public EEstado Estado { get; set; }


        public List<LineaPedidoDTO>? Lineas { get; set; }
       
    }
}

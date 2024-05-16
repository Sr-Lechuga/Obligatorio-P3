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

        [Display(Name = "Fecha prometida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPrometida { get; set; }

        [Display(Name = "Fecha creado")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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

using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
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
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public double IVAAplicado { get; set; }
        public DateTime? FechaEntregado { get; set; }
        public EEstado Estado { get; set; }
        public List<LineaPedidoDTO>? Lineas { get; set; }
       
    }
}

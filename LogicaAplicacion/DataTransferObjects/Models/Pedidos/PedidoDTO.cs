using LogicaNegocio.Entidades;
using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DataTransferObjects.Models.Pedidos
{
    public class PedidoDTO
    {
        public int Id { get; set; } 
        public DateTime FechaPrometida { get; set; }
        public DateTime FechaCreado { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public double IVAAplicado { get; set; }
        public DateTime FechaEntregado { get; set; }
        public EEstado Estado { get; set; }
        public List<LineaPedido> Lineas { get; set; }


    }
}

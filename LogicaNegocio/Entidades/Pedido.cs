using LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Pedido
    {
        #region Properies
        //TODO: Pasar esto a archivo de configuracion
        public static double s_IVA = 22;

        public int Id {  get; set; }

        public DateTime FechaPrometida { get; set; }

        public DateTime FechaCreado { get; set; }

        public Cliente Cliente { get; set; }

        public decimal Total { get; set; }

        public double IVAAplicado { get; set; }

        public List<LineaPedido> Lineas { get; set; }

        public DateTime? FechaEntregado { get; set; }

        public EEstado Estado { get; set; }
        #endregion

        protected Pedido(DateTime fechaPrometida, Cliente cliente)
        {
            FechaPrometida = fechaPrometida;
            FechaCreado = DateTime.Now;
            Cliente = cliente;
            Total = 0;
            IVAAplicado = s_IVA;
            Lineas = [];
            FechaEntregado = null;
            Estado = EEstado.NUEVO;
        }

        #region Methods definitions
        public virtual double CalcularTotal()
        {
            //TODO: Metodo para calcular el total de los pedidos
            double total = 0;
            return total;
        }
        #endregion
    }
}

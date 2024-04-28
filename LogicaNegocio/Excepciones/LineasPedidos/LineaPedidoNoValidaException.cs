using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.LineasPedidos
{
    public class LineaPedidoNoValidaException : Exception
    {
        public LineaPedidoNoValidaException() { }

        public LineaPedidoNoValidaException(string? message) : base(message) { }

        public LineaPedidoNoValidaException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.LineasPedidos
{
    public class LineaPedidoNoEncontradaException : Exception
    {
        public LineaPedidoNoEncontradaException() { }

        public LineaPedidoNoEncontradaException(string? message) : base(message) { }

        public LineaPedidoNoEncontradaException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

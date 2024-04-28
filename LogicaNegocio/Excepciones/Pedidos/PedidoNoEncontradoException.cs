using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Pedidos
{
    public class PedidoNoEncontradoException : Exception
    {
        public PedidoNoEncontradoException() { }

        public PedidoNoEncontradoException(string? message) : base(message) { }

        public PedidoNoEncontradoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

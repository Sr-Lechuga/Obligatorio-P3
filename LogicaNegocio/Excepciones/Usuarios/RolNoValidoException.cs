using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class RolNoValidoException : Exception
    {
        public RolNoValidoException() { }

        public RolNoValidoException(string? message) : base(message) { }

        public RolNoValidoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

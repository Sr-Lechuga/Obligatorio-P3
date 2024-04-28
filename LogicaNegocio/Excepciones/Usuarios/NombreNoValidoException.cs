using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class NombreNoValidoException : Exception
    {
        public NombreNoValidoException() { }

        public NombreNoValidoException(string? message) : base(message) { }

        public NombreNoValidoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class ContraseñaNoValidaException : Exception
    {
        public ContraseñaNoValidaException() { }

        public ContraseñaNoValidaException(string? message) : base(message) { }

        public ContraseñaNoValidaException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

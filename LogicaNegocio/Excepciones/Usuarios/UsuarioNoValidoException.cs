using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioNoValidoException : Exception
    {
        public UsuarioNoValidoException() { }

        public UsuarioNoValidoException(string? message) : base(message) { }

        public UsuarioNoValidoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

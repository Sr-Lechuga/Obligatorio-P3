using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class MailNoValidoException : Exception
    {
        public MailNoValidoException() { }

        public MailNoValidoException(string? message) : base(message) { }

        public MailNoValidoException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

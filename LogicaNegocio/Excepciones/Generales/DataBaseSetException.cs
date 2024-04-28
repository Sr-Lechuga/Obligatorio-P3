﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Generales
{
    public class DataBaseSetException : Exception
    {
        public DataBaseSetException() { }

        public DataBaseSetException(string? message) : base(message) { }

        public DataBaseSetException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}

using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [ComplexType]
    public class NombreCompleto : IValidable<NombreCompleto>
    {
        #region Properties
        public string Nombre { get; init; }
        public string Apellido { get; init; }
        #endregion

        #region Constructors
        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
            EsValido();
        } 

        //Used for EntityFramework
        private NombreCompleto(){}
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarNombre();
            ValidarApellido();
        }

        public void ValidarNombre()
        {
            string patronValido = @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+(?:[' -][a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+)*$";
            
            if (string.IsNullOrEmpty(Nombre))
                throw new NombreNoValidoException("Nombre no puede ser vacío");
            else if (!Regex.IsMatch(Nombre, patronValido))
                throw new NombreNoValidoException("El nombre solo puede contener letras, espacios, apostrofes o guiones. Los caracteres especiales no pueden estar al principio ni al final.");
        }

        public void ValidarApellido()
        {
            string patronValido = @"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+(?:[' -][a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+)*$";
            
            if (string.IsNullOrEmpty(Apellido))
                throw new NombreNoValidoException("Apellido no puede ser vacío");
            else if (!Regex.IsMatch(Apellido, patronValido))
                throw new NombreNoValidoException("El apellido solo puede contener letras, espacios, apostrofes o guiones. Los caracteres especiales no pueden estar al principio ni al final.");
        }
        #endregion

    }
}
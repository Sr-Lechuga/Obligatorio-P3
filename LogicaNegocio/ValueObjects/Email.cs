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
    public class Email : IValidable<Email>
    {
        #region Properties
        public string DireccionEmail { get; init; }
        #endregion

        #region Constructors
        public Email(string direccionEmail)
        {
            DireccionEmail = direccionEmail;
            EsValido();
        }

        //Used for EntityFramework
        private Email(){}
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarDireccionEmail();
        }

        private void ValidarDireccionEmail()
        {
            string patronValido = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(DireccionEmail))
                throw new MailNoValidoException("El email no puede ser vacio.");
            else if (!Regex.IsMatch(DireccionEmail, patronValido))
                throw new MailNoValidoException("Ingrese un email valido");
        }
        #endregion
    }
}

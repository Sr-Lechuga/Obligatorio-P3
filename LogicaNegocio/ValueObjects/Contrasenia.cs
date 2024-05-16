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
    public class Contrasenia : IValidable<Contrasenia>
    {
        #region Properties
        public string Password { get; init; }
        #endregion

        #region Constructors
        public Contrasenia(string password)
        {
            Password = password;
            EsValido();
        }

        //Used for EntityFramework
        private Contrasenia() {}
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarContrasenia();
            EsValido2();
        }

        private void ValidarContrasenia()
        {
            string patronValido = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;!]).{6,}$";
            if (!Regex.IsMatch(Password, patronValido))
                throw new ContraseñaNoValidaException("La contraseña debe tener al menos largo 6. Largo mínimo de 6 caracteres, al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación (.,;!)");
        }

        //Deprecated
        public void EsValido2()
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new ContraseñaNoValidaException("La contraseña no puede ser nula");
            }
            //La contraseña debe tener un largo minimo de 6 caracteres
            if (Password.Length < 6)
            {
                throw new ContraseñaNoValidaException("La contraseña debe tener mas de 6 caracteres");
            }

            //La contraseña debe tener al menos una mayuscula
            if (!Regex.IsMatch(Password, "[A-Z]"))
            {
                throw new ContraseñaNoValidaException("La contraseña debe contener al menos una letra mayúscula.");
            }

            //La contraseña debe tener al menos una minuscula
            if (!Regex.IsMatch(Password, "[a-z]"))
            {
                throw new ContraseñaNoValidaException("La contraseña debe contener al menos una letra minúscula.");
            }

            //La contraseña debe tener al menos un digito
            if (!Regex.IsMatch(Password, @"\d"))
            {
                throw new ContraseñaNoValidaException("La contraseña debe contener al menos un dígito.");
            }

            //La contrasñea debe tener al menos un caracter de puntuacion
            if (!Regex.IsMatch(Password, "[.,;:!]"))
            {
                throw new ContraseñaNoValidaException("La contraseña debe contener al menos uno de los siguientes caracteres: . , ; : !");
            }
        }
        #endregion
    }
}

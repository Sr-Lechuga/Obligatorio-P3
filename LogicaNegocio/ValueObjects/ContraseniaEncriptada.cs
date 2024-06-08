using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [ComplexType]
    public class ContraseniaEncriptada : IValidable<ContraseniaEncriptada>
    {
        #region Properties
        public string ValorContrasenia { get; init; }
        #endregion

        #region Constructors
        public ContraseniaEncriptada(string contrasenia)
        {
            ValorContrasenia = contrasenia;
            EsValido();
            ValorContrasenia = Encriptar(contrasenia);
        }

        //Used for EntityFramework
        private ContraseniaEncriptada() { }
        #endregion

        #region Validations
        public void EsValido()
        {
            ValidarContrasenia();
        }

        private void ValidarContrasenia()
        {
            string patronValido = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;!]).{6,}$";
            
            if (!Regex.IsMatch(ValorContrasenia, patronValido))
                throw new ContraseñaNoValidaException("La contraseña debe tener al menos largo 6. Largo mínimo de 6 caracteres, al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación (.,;!)");
        }
        #endregion
        
        private string Encriptar(string contrasenia)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertimos la contraseña en una secuencia de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));

                // Convertimos los bytes a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
